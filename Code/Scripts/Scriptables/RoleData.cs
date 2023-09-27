using System.Collections.Generic;
using UnityEngine;

namespace WishedAI.Scriptables
{
	/// <summary>
	/// Role of pawn. Contains wishes
	/// </summary>
	[CreateAssetMenu(fileName = "CustomRole", menuName = "WishedAI/New Role")]
	public class RoleData : ScriptableObject
	{
		[SerializeField] private string _title;
		[SerializeField] private string _description;
		[SerializeField] private WishRating[] _wishRatings;

		public string Title
		{
			get => _title;
		}

		public string Description
		{
			get => _description;
		}

		public IEnumerable<WishRating> WishRatings
		{
			get => _wishRatings;
		}
	}
}
