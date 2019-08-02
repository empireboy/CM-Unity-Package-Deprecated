using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials.Inventory
{
	[System.Serializable]
	public class ItemContainer
	{
		[SerializeField] private List<Item> _items;

		private Dictionary<string, Item> _itemsByTitle;

		public void Setup()
		{
			_itemsByTitle = new Dictionary<string, Item>();
			for (int i = 0; i < _items.Count; i++)
				_itemsByTitle.Add(_items[i].Title, _items[i]);
		}

		public Item GetItemByIndex(int index)
		{
			if (index < 0 || index > _items.Count)
			{
				Debug.LogWarning("Item [" + index + "] is out of range");
			} // Debug

			return _items[index] ? _items[index] : null;
		}

		public Item GetItemByTitle(string title)
		{
			if (!_itemsByTitle.ContainsKey(title))
			{
				Debug.LogWarning("Item (" + title + ") is undefined");
			} // Debug

			return _itemsByTitle.ContainsKey(title) ? _itemsByTitle[title] : null;
		}
	}
}