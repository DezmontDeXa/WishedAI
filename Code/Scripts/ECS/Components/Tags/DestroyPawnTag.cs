﻿using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace WishedAI.Ecs.Components.Tags
{
	[System.Serializable]
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	public struct DestroyPawnTag : IComponent
	{
	}
}