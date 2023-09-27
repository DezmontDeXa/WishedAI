using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Helpers;
using Scellecs.Morpeh;
using System.Collections.Generic;
using WishedAI.Scriptables;
using WishedAI.Ecs.Components;
using System.Linq;

namespace WishedAI.Ecs.Systems
{
	/// <summary>
	/// Расчет рейтинга удовлетворителей
	/// </summary>
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	[CreateAssetMenu(menuName = "WishedAI/Systems/" + nameof(CalculateRatingsSystem))]
	public sealed class CalculateRatingsSystem : SimpleUpdateSystem<PawnComponent>
	{
		protected override void Process(Entity entity, ref PawnComponent pawn, in float deltaTime)
		{
			if (!pawn.WishRatingsInitialized)
				InitRatings(ref pawn);

			CalculateRatings(ref pawn, deltaTime);
		}

		private void InitRatings(ref PawnComponent pawn)
		{
			pawn.WishRatings = new List<WishRating>();
			foreach (var wishRating in pawn.Role.WishRatings)
				pawn.WishRatings.Add(wishRating.Clone());

			pawn.WishRatingsInitialized = true;
		}

		private void CalculateRatings(ref PawnComponent pawn, in float deltaTime)
		{
			//TODO: Расчет наилучшего удовлетворителя в случае когда несколько удовлетворителей подходят по желанию

			foreach (var wishRating in pawn.WishRatings)
			{
				if (wishRating.Raters != null && wishRating.Raters.Count() > 0)
				{
					foreach (var rater in wishRating.Raters)
					{
						var newValue = rater.Calculate(wishRating.Rating, deltaTime);
						wishRating.Rating = newValue;
					}
				}

				NormalizeWishRating(wishRating);
			}
		}

		private static void NormalizeWishRating(WishRating wishRating)
		{
			if (wishRating.Rating < 0)
				wishRating.Rating = 0;

			if (wishRating.Rating > 1f)
				wishRating.Rating = 1f;
		}
	}
}