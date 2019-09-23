using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials.Inventory
{
	public class PhysicalInventory : MonoBehaviour
	{
		public Inventory inventory;
		public List<ItemSlot> inventorySlots;
		public bool InitializeOnStart = true;

		private void Start()
		{
			if (InitializeOnStart)
				PopulateInitial();
		}

		public void PopulateInitial()
		{
			for (int i = 0; i < inventorySlots.Count; i++)
			{
				ItemInstance itemInstance;

				if (inventory.GetItem(i, out itemInstance))
				{
					inventorySlots[i].SetItem(itemInstance);
				}
			}
		}

		public void Clear()
		{
			for (int i = 0; i < inventorySlots.Count; i++)
			{
				inventorySlots[i].RemoveItem();
			}
		}
	}
}