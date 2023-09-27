using System;

namespace WishedAI.Core.SatisfyActions
{
	public interface ISatisfyAction
	{
		/// <summary>
		/// Execute on time on begin satisfy action
		/// </summary>
		/// <param name="context"></param>
		/// <returns>True - if action completed</returns>
		bool Start(SatisfyActionContext context);

		/// <summary>
		/// Execute every frame
		/// </summary>
		/// <param name="context"></param>
		/// <param name="timeDelta"></param>
		/// <returns>True - if action completed</returns>
		bool Update(SatisfyActionContext context, float timeDelta);
	}
}
