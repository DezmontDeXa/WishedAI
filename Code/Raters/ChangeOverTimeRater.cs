using System;
using WishedAI.Core.Raters;

namespace WishedAI.Raters
{
	[Serializable]
	public class ChangeOverTimeRater : IWishRater
	{
		public float ChangePerSecond = -0.1f;

		public float Calculate(float currentValue, float deltaTime)
		{
			return currentValue + (ChangePerSecond * deltaTime);
		}
	}
}
