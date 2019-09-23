using UnityEngine;

namespace CM.Essentials.Inventory
{
	[System.Serializable]
	[CreateAssetMenu(menuName = "CM/Essentials/Inventory/New Inventory", fileName = "NewInventory.asset")]
	public class Inventory : ScriptableObject
	{
		public ItemInstance[] stock;

		public bool SlotEmpty(int index)
		{
			return (stock[index] == null || stock[index].item == null) ? true : false;
		}

		public bool GetItem(int index, out ItemInstance item)
		{
			if (SlotEmpty(index))
			{
				item = null;
				return false;
			}

			item = stock[index];
			return true;
		}

		public bool RemoveItem(int index)
		{
			if (SlotEmpty(index))
			{
				return false;
			}

			stock[index] = null;

			return true;
		}

		public int InsertItem(ItemInstance item)
		{
			for (int i = 0; i < stock.Length; i++)
			{
				if (SlotEmpty(i))
				{
					stock[i] = item;
					return i;
				}
			}

			return -1;
		}
	}
}