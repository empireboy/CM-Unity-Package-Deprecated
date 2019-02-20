using System.Collections.Generic;
using UnityEngine;
using CM.Essentials.GridExtension;
using NaughtyAttributes;

namespace CM.Essentials.Inventory
{
	[System.Serializable]
	[CreateAssetMenu(menuName = "CM/Essentials/Inventory/New Inventory", fileName = "NewInventory.asset")]
	public class Inventory : ScriptableObject, IInventory
	{
		[SerializeField] private string _title;
		public string Title { get { return _title; } set { _title = value; } }
		[SerializeField] private bool _infiniteSize;
		public bool InfiniteSize { get { return _infiniteSize; } }
		[HideIf("_infiniteSize")]
		[SerializeField] private int _rows;
		public int Rows { get { return _rows; } set { _rows = value; } }
		[HideIf("_infiniteSize")]
		[SerializeField] private int _columns;
		public int Columns { get { return _columns; } set { _columns = value; } }
		[SerializeField] private bool _canContainAllItems = true;
		[HideIf("_canContainAllItems")]
		[SerializeField] private List<string> _containingItemsByTitleList;

		private Dictionary<int, string> _containingItemsByTitle;

		private Item[,] _stock;

		public delegate void SetupHandler(Inventory inventory);
		public event SetupHandler OnSetupFinished;
		public delegate void ItemAddedHandler(Inventory inventory, Item item, int row, int column);
		public event ItemAddedHandler OnItemAdded;

		public void Setup()
		{
			_containingItemsByTitle = new Dictionary<int, string>();
			for (int i = 0; i < _containingItemsByTitleList.Count; i++)
				_containingItemsByTitle.Add(i, _containingItemsByTitleList[i]);

			_stock = (_infiniteSize) ? new Item[_rows, _columns] : new Item[1, 1];

			OnSetupFinished?.Invoke(this);
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

			if (!_canContainAllItems && !_containingItemsByTitle.ContainsValue(item.Title))
			{
				Debug.LogWarning("Item (" + item.Title + ") can't be placed in this inventory (" + _title + ")");
				return;
			} // Debug

			// Adding item to row and column
			_stock[row, column] = item;

			OnItemAdded?.Invoke(this, item, row, column);
		}

		public void AddItem(Item item)
		{
			if (item == null)
			{
				Debug.LogWarning("Item (" + "undefined" + ") can't be placed in this inventory (" + _title + ")");
				return;
			} // Debug

			if (!_infiniteSize)
			{
				Debug.LogWarning("Inventory (" + _title + ") is not an infinite inventory");
				return;
			} // Debug

			if (!_canContainAllItems && !_containingItemsByTitle.ContainsValue(item.Title))
			{
				Debug.LogWarning("Item (" + item.Title + ") can't be placed in this inventory (" + _title + ")");
				return;
			} // Debug

			// Adding item
			int row = _stock.Length;
			int column = 0;

			_stock[row, column] = item;

			OnItemAdded?.Invoke(this, item, row, column);
		}
	}
}