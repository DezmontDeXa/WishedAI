using Scellecs.Morpeh;
using WishedAI.Core.SatisfyActions;
using WishedAI.Ecs.Components.Tags;

namespace WishedAI.SatisfyActions.Pawn
{
	public class Destroy : SatisfyActionBase
	{
		public override bool Start(SatisfyActionContext context)
		{
			context.PawnEntity.AddComponent<DestroyPawnTag>();
			return true;
		}

		public override bool Update(SatisfyActionContext context, float timeDelta)
		{
			return false;
		}
	}

}
