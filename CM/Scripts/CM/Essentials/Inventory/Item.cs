using UnityEngine;

namespace CM.Essentials.Inventory
{
	[System.Serializable]
	[CreateAssetMenu(menuName = "CM/Essentials/Inventory/New Item", fileName = "NewItem.asset")]
	public class Item : ScriptableObject
	{
		[SerializeField] private string _title;
		public string Title { get { return _title; } set { _title = value; } }
		[SerializeField] private string _description;
		public string Description { get { return _description; } set { _description = value; } }

		public Item(string title, string description)
		{
			_title = title;
			_description = description;
		}
	}
}