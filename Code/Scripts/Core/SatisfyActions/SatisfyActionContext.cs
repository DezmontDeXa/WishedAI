using Scellecs.Morpeh;

namespace WishedAI.Core.SatisfyActions
{
	public class SatisfyActionContext
	{
		public World World
		{
			get;
		}
		public Entity SatisfierEntity
		{
			get;
		}
		public Entity PawnEntity
		{
			get;
		}

		public SatisfyActionContext(World world, Entity satisfierEntity, Entity pawnEntity)
		{
			World = world;
			SatisfierEntity = satisfierEntity;
			PawnEntity = pawnEntity;
		}
	}
}