using UnityEngine;
using UnityEngine.Events;
using WishedAI.Core.SatisfyActions;

namespace WishedAI.SatisfyActions.Mono
{
	[System.Serializable]	
	public class InvokeMethod : SatisfyActionBase
	{
		[SerializeField] [TriInspector.DrawWithUnity] private UnityEvent _action;

		public override bool Start(SatisfyActionContext context)
		{
			_action.Invoke();
			return true;
		}

		public override bool Update(SatisfyActionContext context, float timeDelta)
		{
			return false;
		}
	}
}
