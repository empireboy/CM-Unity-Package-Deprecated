using System.Collections.Generic;
using UnityEngine;
using CM.Essentials.GridExtension;

namespace CM.Essentials.Inventory
{
	[System.Serializable]
	[CreateAssetMenu(menuName = "CM/Essentials/Inventory/New Inventory", fileName = "NewInventory.asset")]
	public class Inventory : ScriptableObject, IInventory
	{
		[SerializeField] private string _title;
		public string Title { get { return _title; } set { _title = value; } }
		[SerializeField] private int _rows;
		public int Rows { get { return _rows; } set { _rows = value; } }
		[SerializeField] private int _columns;
		public int Columns { get { return _columns; } set { _columns = value; } }
		[SerializeField] private List<string> _containingItemsByTitleTemp;

		private Dictionary<int, string> _containingItemsByTitle;

		private Item[,] _stock;

		public delegate void SetupHandler(Inventory inventory);
		public event SetupHandler OnSetupFinished;
		public delegate void ItemAddedHandler(Inventory inventory, Item item, int row, int column);
		public event ItemAddedHandler OnItemAdded;

		public void Setup()
		{
			_containingItemsByTitle = new Dictionary<int, string>();
			for (int i = 0; i < _containingItemsByTitleTemp.Count; i++)
				_containingItemsByTitle.Add(i, _containingItemsByTitleTemp[i]);

			_stock = new Item[_rows, _columns];

			if (OnSetupFinished != null)
				OnSetupFinished(this);
		}

		public Item GetItem(int row, int column)
		{
			if (!GridExt.IsInRange<Item>(_stock, new Vector2(row, column)))
			{
				Debug.LogWarning("Grid position (" + row + "," + column + ") in Inventory [" + _title + "] is out of range");
			} // Debug
			
			return GridExt.IsInRange<Item>(_stock, new Vector2(row, column)) ? _stock[row, column] : null;
		}

		public void AddItem(Item item, int row, int column)
		{
			if (item == null)
			{
				Debug.LogWarning("Item (" + "undefined" + ") can't be placed in this inventory (" + _title + ")");
				return;
			} // Debug

			if (!GridExt.IsInRange<Item>(_stock, new Vector2(row, column)))
			{
				Debug.LogWarning("Grid position (" + row + "," + column + ") in Inventory [" + _title + "] is out of range");
				return;
			} // Debug

			if (_containingItemsByTitle.ContainsValue(item.Title))
			{
				_stock[row, column] = item;

				if (OnItemAdded != null)
					OnItemAdded(this, item, row, column);
			} // Adding item to row and column
			else
			{
				Debug.LogWarning("Item (" + item.Title + ") can't be placed in this inventory (" + _title + ")");
			} // Debug
		}
	}
}