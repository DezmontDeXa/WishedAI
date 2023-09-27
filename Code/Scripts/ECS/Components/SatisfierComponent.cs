using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using WishedAI.Core.SatisfyActions;
using WishedAI.Scriptables;

namespace WishedAI.Ecs.Components
{
	[System.Serializable]
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	public struct SatisfierComponent : IComponent
	{
		public WishData TargetWish;
		[SerializeReference] public ISatisfyAction[] Actions;
		[HideInInspector] public GameObject GameObject;
		public float RatingChange;
		public int MaxPawnsCount;
		public bool UnlimitedPawnsCount;

		public override string ToString()
		{
			return GameObject.name;
		}
	}
}