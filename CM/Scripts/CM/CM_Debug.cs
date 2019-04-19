using System.Collections.Generic;
using UnityEngine;

namespace CM
{
	public static class CM_Debug
	{
		public static Dictionary<string, bool> categories = new Dictionary<string, bool>();

		public static void Log(string category, object message)
		{
			// Add category if it doesn't exist
			if (!categories.ContainsKey(category))
			{
				categories.Add(category, false);
			}

			// Return if the current category is set to false
			if (!categories[category])
				return;

			Debug.Log("[" + category + "] " + message);
		}

		public static void AddCategory(string category, bool value)
		{
			categories.Add(category, value);
		}
	}
}