using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Helpers;
using Scellecs.Morpeh;
using System.Linq;
using WishedAI.Ecs.Components;
using WishedAI.Ecs.Components.Tags;
using Scellecs.Morpeh.Systems;

namespace WishedAI.Ecs.Systems
{
	/// <summary>
	/// Выбрать наилучший свободный сатисфаер на основе рейтинга
	/// </summary>
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	[CreateAssetMenu(menuName = "WishedAI/Systems/" + nameof(BeginSatisfySystem))]
	public sealed class BeginSatisfySystem : UpdateSystem
	{
		[SerializeField] private bool _useLog = false;
		private Filter _freeSatisfiersFilter;

		public override void OnAwake()
		{
			_freeSatisfiersFilter = World.Filter
				.With<SatisfierComponent>()
				.Without<BusyTag>()
				.Build();
		}

		public override void OnUpdate(float deltaTime)
		{
			if (_freeSatisfiersFilter == null)
				return;

			foreach (var pawnEntity in World.Filter.With<PawnComponent>().Without<BusyTag>().Build())
			{
				ref var pawn = ref pawnEntity.GetComponent<PawnComponent>();

				foreach (var wishRating in pawn.WishRatings.OrderByDescending(x => x.Rating))
				{
					foreach (var satisfierEntity in _freeSatisfiersFilter)
					{
						var satisfier = satisfierEntity.GetComponent<SatisfierComponent>();

						if (satisfier.TargetWish == wishRating.Wish)
						{
							CreateSatisfy(pawnEntity, satisfierEntity);
							if (_useLog)
								Debug.Log($"BeginSatisfySystem: {pawn} begin statisfy on {satisfier}");
							return;
						}
					}
				}
			}
		}

		private void CreateSatisfy(Entity pawnEntity, Entity satisfierEntity)
		{
			var satisfyEntity = World.CreateEntity();
			ref var satisfy = ref satisfyEntity.AddComponent<SatisfyComponent>();
			satisfy.SatisfierEntity = satisfierEntity;
			satisfy.PawnEntity = pawnEntity;
			satisfy.ActionIndex = 0;
			satisfy.StartWasExecuted = false;
			satisfy.ActionsCount = satisfierEntity.GetComponent<SatisfierComponent>().Actions.Length;
		}
	}
}