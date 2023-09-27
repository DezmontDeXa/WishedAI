using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Helpers;
using Scellecs.Morpeh;
using WishedAI.Ecs.Components;
using WishedAI.Ecs.Components.Tags;
using System.Linq;
using System;

namespace WishedAI.Ecs.Systems
{
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	[CreateAssetMenu(menuName = "WishedAI/Systems/" + nameof(DestroyPawnSystem))]
	public sealed class DestroyPawnSystem : SimpleLateUpdateSystem<PawnComponent, DestroyPawnTag>
	{
		protected override void Process(Entity entity, ref PawnComponent first, ref DestroyPawnTag second, in float deltaTime)
		{
			World.RemoveEntity(entity);
		}
	}
}