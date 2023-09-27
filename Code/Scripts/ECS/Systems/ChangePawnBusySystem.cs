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
	[CreateAssetMenu(menuName = "WishedAI/Systems/" + nameof(ChangePawnBusySystem))]
	public sealed class ChangePawnBusySystem : SimpleUpdateSystem<PawnComponent>
	{
		[SerializeField] private bool _useLog = false;
		protected override void Process(Entity pawnEntity, ref PawnComponent pawn, in float deltaTime)
		{
			var satisfies = World.Filter.With<SatisfyComponent>().Build();

			foreach (var satisfyEntity in satisfies)
			{
				var satisfy = satisfyEntity.GetComponent<SatisfyComponent>();
				if (satisfy.PawnEntity.ID == pawnEntity.ID)
				{
					MakeBusy(pawnEntity);
					return;
				}
			}

			MakeFree(pawnEntity);
		}

		private void MakeFree(Entity pawnEntity)
		{
			if (pawnEntity.Has<BusyTag>())
			{
				pawnEntity.RemoveComponent<BusyTag>();
				if (_useLog)
					Debug.Log($"ChangePawnBusySystem: {pawnEntity}  maked Free");
			}
		}

		private void MakeBusy(Entity pawnEntity)
		{
			if (!pawnEntity.Has<BusyTag>())
			{
				pawnEntity.AddComponent<BusyTag>();
				if (_useLog)
					Debug.Log($"ChangePawnBusySystem: {pawnEntity}  maked Busy");
			}
		}
	}
}