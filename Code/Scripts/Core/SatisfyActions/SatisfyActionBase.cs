namespace WishedAI.Core.SatisfyActions
{
	public abstract class SatisfyActionBase : ISatisfyAction
	{
		public abstract bool Start(SatisfyActionContext context);

		public abstract bool Update(SatisfyActionContext context, float timeDelta);
	}
}
