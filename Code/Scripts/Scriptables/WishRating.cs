using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WishedAI.Core.Raters;

namespace WishedAI.Scriptables
{
	[Serializable]
	public class WishRating
	{
		[SerializeField] private WishData _wish;
		[SerializeField] private float _rating;
		[SerializeField] [SerializeReference] private IWishRater[] _raters;

		public WishData Wish => _wish;
		public float Rating
		{
			get => _rating;
			set => _rating = value;
		}
		public IEnumerable<IWishRater> Raters => _raters;

		public WishRating Clone()
		{
			return new WishRating()
			{
				_wish = Wish,
				_rating = Rating,
				_raters = Raters.ToArray()
			};
		}
	}
}
