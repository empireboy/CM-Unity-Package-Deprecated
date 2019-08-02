using UnityEngine;
using System.Collections.Generic;

namespace CM.Essentials.Inventory
{
	public class InventoryManager : MonoBehaviour
	{
		[SerializeField] private List<InventoryContainer> _inventoryContainers;
		public List<InventoryContainer> InventoryContainer
		{
			get
			{
				return _inventoryContainers;
			}
		}

		[SerializeField] private ItemContainer _itemContainer;
		public ItemContainer ItemContainer
		{
			get
			{
				return _itemContainer;
			}
		}

		private void Start()
		{
			_inventoryContainers[0].Setup();
			_itemContainer.Setup();

			_inventoryContainers[0].GetInventoryByIndex(0).AddItem(_itemContainer.GetItemByIndex(0), 2, 1);

			Debug.Log(_inventoryContainers[0].GetInventoryByIndex(0).GetItem(2, 1).Title);
			Debug.Log(_inventoryContainers[0].GetInventoryByIndex(0).GetItem(2, 1).Description);
		}
	}
}