using Scellecs.Morpeh;
using UnityEngine;
using WishedAI.Core.SatisfyActions;
using WishedAI.Ecs.Components;
using WishedAI.Ecs.Components.Tags;

namespace WishedAI.SatisfyActions.Pawn.Animations
{
	public class SetTrigger : SatisfyActionBase
	{
		[SerializeField] private string _triggerName;

		public override bool Start(SatisfyActionContext context)
		{
			var animator = context.PawnEntity.GetComponent<PawnComponent>()
				.GameObject.GetComponentInChildren<Animator>();
			animator.SetTrigger(_triggerName);
			return true;
		}

		public override bool Update(SatisfyActionContext context, float timeDelta)
		{
			return false;
		}
	}
}
