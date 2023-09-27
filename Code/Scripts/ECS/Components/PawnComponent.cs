using Scellecs.Morpeh;
using System.Collections.Generic;
using TriInspector;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using WishedAI.Scriptables;

namespace WishedAI.Ecs.Components
{
	[System.Serializable]
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	public struct PawnComponent : IComponent
	{
		public RoleData Role;
		public NavMeshAgent NavMeshAgent;
		public Transform Transform;
		[HideInInspector] public GameObject GameObject;
		[ReadOnly] public bool WishRatingsInitialized;
		[ReadOnly] public List<WishRating> WishRatings;

		public override string ToString()
		{
			return GameObject.name;
		}
	}
}