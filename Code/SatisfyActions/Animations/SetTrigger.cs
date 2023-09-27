using UnityEngine;
using WishedAI.Core.SatisfyActions;

namespace WishedAI.SatisfyActions.Animations
{
	public class SetTrigger : SatisfyActionBase
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private string _triggerName;

		public override bool Start(SatisfyActionContext context)
		{
			_animator.SetTrigger(_triggerName);
			return true;
		}

		public override bool Update(SatisfyActionContext context, float timeDelta)
		{
			return false;
		}
	}
}
