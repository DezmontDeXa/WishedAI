using Scellecs.Morpeh;
using System;
using Unity.IL2CPP.CompilerServices;

namespace WishedAI.Ecs.Components
{
	/// <summary>
	/// Представляет процесс удовлетворения конкретной пешки конкретным удовлетворителем
	/// </summary>
	[System.Serializable]
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	public struct SatisfyComponent : IComponent
	{
		public Entity PawnEntity;
		public Entity SatisfierEntity;
		public int ActionIndex;
		public bool StartWasExecuted;
		public int ActionsCount;
	}
}