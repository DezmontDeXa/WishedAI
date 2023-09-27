using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WishedAI.Core.Raters;

namespace WishedAI.Scriptables
{
	/// <summary>
	/// Wish info
	/// </summary>
	[Serializable]
	[CreateAssetMenu(fileName = "CustomWish", menuName = "WishedAI/New Wish")]
	public class WishData : ScriptableObject
	{
		[SerializeField] private string _title = "Custom wish";
		[SerializeField] private string _description = "SomeDescription";
		[SerializeReference] private IWishRater[] _raters;

		public string Title
		{
			get => _title;
		}

		public string Description
		{
			get => _description;
		}

		public IEnumerable<IWishRater> Raters
		{
			get => _raters;
		}
	}
}
