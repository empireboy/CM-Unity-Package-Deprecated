using UnityEngine;

namespace CM.Essentials.Inventory
{
	[System.Serializable]
	public abstract class Item : ScriptableObject
	{
		public string itemName = "undefined";
		public string itemDescription;
		public GameObject physicalRepresentation;
		public int stackLimit = 1;
	}
}