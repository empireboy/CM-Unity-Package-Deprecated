namespace CM.Essentials.Inventory
{
	public interface IInventory
	{
		Item GetItem(int row, int colomn);
		void AddItem(Item item, int row, int colomn);
		void AddItem(Item item);
	}
}