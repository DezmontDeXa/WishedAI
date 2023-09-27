using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Helpers;
using Scellecs.Morpeh;
using WishedAI.Ecs.Components;
using WishedAI.Ecs.Components.Tags;

namespace WishedAI.Ecs.Systems
{
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	[CreateAssetMenu(menuName = "WishedAI/Systems/" + nameof(ChangeSatisfierBusySystem))]
	public sealed class ChangeSatisfierBusySystem : SimpleUpdateSystem<SatisfierComponent>
	{
		[SerializeField] private bool _useLog = false;
		protected override void Process(Entity satisfierEntity, ref SatisfierComponent satisfier, in float deltaTime)
		{
			if (satisfier.UnlimitedPawnsCount)
				return;
			var pawnsCount = CalculateSatisfierPawnsCount(satisfierEntity);
			if (pawnsCount >= satisfier.MaxPawnsCount)
				MakeBusy(satisfierEntity);
			else
				MakeFree(satisfierEntity);
		}

		private void MakeFree(Entity satisfierEntity)
		{
			if (satisfierEntity.Has<BusyTag>())
			{
				satisfierEntity.RemoveComponent<BusyTag>();
				if (_useLog)
					Debug.Log($"ChangeSatisfierBusySystem: {satisfierEntity}  maked Free");
			}
		}

		private void MakeBusy(Entity satisfierEntity)
		{
			if (!satisfierEntity.Has<BusyTag>())
			{
				satisfierEntity.AddComponent<BusyTag>();
				if (_useLog)
					Debug.Log($"ChangeSatisfierBusySystem: {satisfierEntity}  maked Busy");
			}
		}

		private int CalculateSatisfierPawnsCount(Entity satisfierEntity)
		{
			var satisfies = World.Filter.With<SatisfyComponent>().Build();

			int satisfierPawnsCount = 0;
			foreach (var satisfyEntity in satisfies)
			{
				var satisfy = satisfyEntity.GetComponent<SatisfyComponent>();
				if (satisfy.SatisfierEntity.ID == satisfierEntity.ID)
					satisfierPawnsCount++;
			}
			return satisfierPawnsCount;
		}
	}
}