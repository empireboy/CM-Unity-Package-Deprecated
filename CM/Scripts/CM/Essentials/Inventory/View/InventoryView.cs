/*
using UnityEngine.UI;
using UnityEngine;
using CM.Essentials.GridExtension;

namespace CM.Essentials.Inventory
{
	[RequireComponent(typeof(GridLayoutGroup))]
	[RequireComponent(typeof(RectTransform))]
	public abstract class InventoryView<T> : MonoBehaviour where T : GridTile
	{
		[SerializeField] private Inventory _inventory;
		[SerializeField] private GridTile _slot;
		[SerializeField] protected GameObject slotItem;

		protected GridTile[,] grid;

		private void Awake()
		{
			_inventory.OnSetupFinished += Init;
			_inventory.OnItemAdded += OnItemAdded;
		}

		public virtual void Init(Inventory inventory)
		{
			GetComponent<GridLayoutGroup>().constraintCount = inventory.Rows;

			grid = new T[inventory.Rows, inventory.Columns];

			for (int i = 0; i < inventory.Rows; i++)
			{
				for (int j = 0; j < inventory.Columns; j++)
				{
					GridTile newInventorySlot = Instantiate(_slot, transform);
					grid[i, j] = newInventorySlot;
					newInventorySlot.SetGridPosition(new Vector2(i, j));
				}
			}
		}

		public abstract void OnItemAdded(Inventory inventory, Item item, int row, int column);
	}
}
*/