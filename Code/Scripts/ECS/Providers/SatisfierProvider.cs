using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;
using WishedAI.Ecs.Components;
using Scellecs.Morpeh;

namespace WishedAI.Ecs.Providers
{
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	public sealed class SatisfierProvider : MonoProvider<SatisfierComponent>
	{
		protected override void Initialize()
		{
			base.Initialize();
			ref var data = ref GetData();
			data.GameObject = gameObject;
		}

		private void Update()
		{
			if (Entity.IsNullOrDisposed())
				Destroy(gameObject);
		}
	}	
}