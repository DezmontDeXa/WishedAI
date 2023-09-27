using UnityEngine;
using WishedAI.Core.SatisfyActions;

namespace WishedAI.SatisfyActions.Other
{
	public class WaitAction : SatisfyActionBase
	{
		[SerializeField] private float _delay;
		private float _remainingTime = 0;

		public override bool Start(SatisfyActionContext context)
		{
			_remainingTime = _delay;
			return false;
		}

		public override bool Update(SatisfyActionContext context, float timeDelta)
		{
			_remainingTime -= timeDelta;
			return _remainingTime <= 0;
		}
	}
}
