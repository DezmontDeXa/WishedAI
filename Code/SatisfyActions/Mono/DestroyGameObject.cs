using UnityEngine;
using WishedAI.Core.SatisfyActions;

namespace WishedAI.SatisfyActions.Mono
{
	public class DestroyGameObject : SatisfyActionBase
	{
		[SerializeField] private GameObject _target;

		public override bool Start(SatisfyActionContext context)
		{
			Object.Destroy( _target );
			return true;
		}

		public override bool Update(SatisfyActionContext context, float timeDelta)
		{
			return false;
		}
	}
}
