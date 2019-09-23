namespace CM.Essentials.Inventory
{
	[System.Serializable]
	public class ItemInstance
	{
		public Item item;
		public int quantity;

		public ItemInstance(Item item, int quantity)
		{
			this.item = item;
			this.quantity = quantity;
		}
	}
}