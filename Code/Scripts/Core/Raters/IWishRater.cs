namespace WishedAI.Core.Raters
{
	/// <summary>
	/// Wish rating calculator
	/// </summary>
	public interface IWishRater
	{
		float Calculate(float currentValue, float deltaTime);
	}
}
