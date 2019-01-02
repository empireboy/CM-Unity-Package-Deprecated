using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials.Inventory
{
	[System.Serializable]
	public class InventoryContainer
	{
		[SerializeField] private List<Inventory> _inventories;

		private Dictionary<string, Inventory> _inventoriesByTitle;

		public void Setup()
		{
			foreach (Inventory inventory in _inventories)
				inventory.Setup();

			_inventoriesByTitle = new Dictionary<string, Inventory>();
			for (int i = 0; i < _inventories.Count; i++)
				_inventoriesByTitle.Add(_inventories[i].Title, _inventories[i]);
		}

		public Inventory GetInventoryByIndex(int index)
		{
			if (index < 0 || index >= _inventories.Count)
			{
				Debug.LogWarning("Inventory [" + index + "] is out of range");
			} // Debug

			return index >= 0 && index < _inventories.Count ? _inventories[index] : null;
		}

		public Inventory GetInventoryByTitle(string title)
		{
			if (!_inventoriesByTitle.ContainsKey(title))
			{
				Debug.LogWarning("Inventory (" + title + ") is undefined");
			} // Debug

			return _inventoriesByTitle.ContainsKey(title) ? _inventoriesByTitle[title] : null;
		}
	}
}