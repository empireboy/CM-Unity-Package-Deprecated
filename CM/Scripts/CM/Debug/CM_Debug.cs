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
			if (!CategoryExists(category))
			{
				categories.Add(category, false);
			}

			// Return if the current category is set to false
			if (!categories[category])
				return;

			Debug.Log("[" + category + "] " + message);
		}

		public static void LogWarning(string category, object message)
		{
			// Add category if it doesn't exist
			if (!CategoryExists(category))
			{
				categories.Add(category, false);
			}

			// Return if the current category is set to false
			if (!categories[category])
				return;

			Debug.LogWarning("[" + category + "] " + message);
		}

		public static void LogError(string category, object message)
		{
			// Add category if it doesn't exist
			if (!CategoryExists(category))
			{
				categories.Add(category, false);
			}

			// Return if the current category is set to false
			if (!categories[category])
				return;

			Debug.LogError("[" + category + "] " + message);
		}

		public static void AddCategory(string category, bool value)
		{
			// Check if the category already exists
			if (CategoryExists(category))
			{
				Debug.LogWarning("The category " + category + " already exists. You may want to use CM_Debug.CategoryExists to check if the category already exists");
				return;
			}

			categories.Add(category, value);
		}

		public static void SetCategory(string category, bool value)
		{
			// Check if the category already exists
			if (!CategoryExists(category))
			{
				Debug.LogWarning("Tried setting " + category + " to " + value + ". The category does not exist");
				return;
			}

			categories[category] = value;
		}

		public static bool CategoryExists(string category)
		{
			return categories.ContainsKey(category);
		}
	}
}