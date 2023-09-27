using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Helpers;
using Scellecs.Morpeh;
using WishedAI.Core.SatisfyActions;
using WishedAI.Ecs.Components;
using System.Linq;

namespace WishedAI.Ecs.Systems
{
	/// <summary>
	/// Переключение ISatisfyActions 
	/// </summary>
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	[CreateAssetMenu(menuName = "WishedAI/Systems/" + nameof(SatisfySystem))]
	public sealed class SatisfySystem : SimpleUpdateSystem<SatisfyComponent>
	{
		[SerializeField] private bool _useLog = false;
		protected override void Process(Entity satisfyEntity, ref SatisfyComponent satisfy, in float deltaTime)
		{
			ref var satisfier = ref satisfy.SatisfierEntity.GetComponent<SatisfierComponent>();
			ref var pawn = ref satisfy.PawnEntity.GetComponent<PawnComponent>();
			var context = new SatisfyActionContext(
					World,
					satisfy.SatisfierEntity,
					satisfy.PawnEntity);

			if (!satisfy.StartWasExecuted)
			{
				var startResult = ExecuteStart(ref satisfy, ref satisfier, ref pawn, context);
				if (startResult)
				{
					NextAction(ref satisfy);
					if (_useLog)
						Debug.Log($"SatisfySystem.Satisfy({satisfyEntity}): {satisfy.PawnEntity} actionIndex upped to {satisfy.ActionIndex}");
				}
			}
			else
			{
				var updateResult = ExecuteUpdate(ref satisfy, ref satisfier, ref pawn, context, deltaTime);
				if (updateResult)
				{
					NextAction(ref satisfy);
					if (_useLog)
						Debug.Log($"SatisfySystem.Satisfy({satisfyEntity}): {satisfy.PawnEntity} actionIndex upped to {satisfy.ActionIndex}");
				}
			}

			if (satisfy.ActionIndex >= satisfy.ActionsCount)
			{
				ApplySatisfierRatingChange(satisfyEntity);
				FinishSatisfy(satisfyEntity);
				if (_useLog)
					Debug.Log($"SatisfySystem.Satisfy({satisfyEntity}): Finished");
			}
		}

		private bool ExecuteStart(ref SatisfyComponent satisfy, ref SatisfierComponent satisfier, ref PawnComponent pawn, SatisfyActionContext context)
		{
			var action = satisfier.Actions[satisfy.ActionIndex];
			satisfy.StartWasExecuted = true;
			var actionResult = action.Start(context);
			return actionResult;
		}

		private bool ExecuteUpdate(ref SatisfyComponent satisfy, ref SatisfierComponent satisfier, ref PawnComponent pawn, SatisfyActionContext context, float timeDelta)
		{
			var action = satisfier.Actions[satisfy.ActionIndex];
			var actionResult = action.Update(context, timeDelta);
			return actionResult;
		}

		private void NextAction(ref SatisfyComponent satisfy)
		{
			satisfy.ActionIndex++;
			satisfy.StartWasExecuted = false;
		}

		private void FinishSatisfy(Entity satisfyEntity)
		{
			World.RemoveEntity(satisfyEntity);
		}

		private static void ApplySatisfierRatingChange(Entity satisfyEntity)
		{
			var satisfy = satisfyEntity.GetComponent<SatisfyComponent>();
			var satisfier = satisfy.SatisfierEntity.GetComponent<SatisfierComponent>();
			ref var pawn = ref satisfy.PawnEntity.GetComponent<PawnComponent>();
			pawn.WishRatings.First(x => x.Wish == satisfier.TargetWish).Rating += satisfier.RatingChange;
		}
	}
}