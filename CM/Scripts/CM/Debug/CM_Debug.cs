using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CM
{
	public static class CM_Debug
	{
		public class Category
		{
			public string Name { get; set; }
			private bool _active;
			public bool Active
			{
				get
				{
					return _active;
				}

				set
				{
					_active = value;

					if (InnerCategory == null)
						return;

					switch (value)
					{
						case true:
							foreach (string key in InnerCategory.Keys)
							{
								InnerCategory[key].Active = true;
							}
							break;
						case false:
							foreach (string key in InnerCategory.Keys)
							{
								InnerCategory[key].Active = false;
							}
							break;
					}
				}
			}

			public Dictionary<string, Category> InnerCategory { get; set; }

			public Category(string name, bool active)
			{
				Name = name;
				Active = active;
				InnerCategory = new Dictionary<string, Category>();
			}

			public static implicit operator bool(Category category)
			{
				return (category != null);
			}
		}

		public static string defaultCategoryName = "Custom";
		public static bool initialized = false;
		public static Category mainCategory;

		public static void Initialize()
		{
			mainCategory = new Category("All Categories", true);
			mainCategory.InnerCategory.Add(defaultCategoryName, new Category(defaultCategoryName, true));
			initialized = true;
		}

		public static void Log(object message, params string[] categories)
		{
			if (mainCategory == null)
				Initialize();

			// Add category if it doesn't exist
			if (!CategoryExists(true, categories))
			{
				AddCategory(false, categories);
			}

			// Return if the current category is set to false
			if (!GetCategory(categories).Active)
				return;

			string categoryString = CategoriesListToString(categories);

			Debug.Log("[" + categoryString + "] " + message);
		}

		/*
		public static void Log(string subCategory, string category, object message)
		{
			if (mainCategory == null)
				Initialize();

			// Add sub category if it doesn't exist
			if (!CategoryExists(subCategory, category))
			{
				mainCategory.InnerCategory.Add(subCategory, new Category(subCategory, true));
			}

			// Add category if it doesn't exist
			if (!CategoryExists(subCategory, category))
			{
				mainCategory.InnerCategory[subCategory].InnerCategory.Add(category, new Category(subCategory, false));
			}

			// Return if the current category is set to false
			if (!mainCategory.InnerCategory[subCategory].InnerCategory[category].Active)
				return;

			Debug.Log("[" + category + "] " + message);
		}
		*/

		public static void LogWarning(string category, object message)
		{
			if (mainCategory == null)
				Initialize();

			// Add category if it doesn't exist
			if (!CategoryExists(category))
			{
				mainCategory.InnerCategory[defaultCategoryName].InnerCategory.Add(category, new Category(category, false));
			}

			// Return if the current category is set to false
			if (!mainCategory.InnerCategory[defaultCategoryName].InnerCategory[category].Active)
				return;

			Debug.LogWarning("[" + category + "] " + message);
		}

		public static void LogError(string category, object message)
		{
			if (mainCategory == null)
				Initialize();

			// Add category if it doesn't exist
			if (!CategoryExists(category))
			{
				mainCategory.InnerCategory[defaultCategoryName].InnerCategory.Add(category, new Category(category, false));
			}

			// Return if the current category is set to false
			if (!mainCategory.InnerCategory[defaultCategoryName].InnerCategory[category].Active)
				return;

			Debug.LogError("[" + category + "] " + message);
		}

		public static void AddCategory(string category, bool value)
		{
			if (mainCategory == null)
				Initialize();

			// Check if the category already exists
			if (CategoryExists(mainCategory.Name, defaultCategoryName, category))
			{
				//Debug.LogWarning("The category " + category + " already exists. You may want to use CM_Debug.CategoryExists to check if the category already exists.");
				return;
			}

			Category parentCategory = GetCategory(mainCategory.Name, defaultCategoryName);

			if (!parentCategory)
			{
				//Debug.LogWarning("Can't add the category " + category + " because the parent category does not exist.");
				return;
			}

			parentCategory.InnerCategory.Add(category, new Category(category, value));
		}

		public static void AddCategory(bool value, params string[] categories)
		{
			if (mainCategory == null)
				Initialize();

			List<string> categoriesList = new List<string>(categories);
			categoriesList.Insert(0, mainCategory.Name);
			string categoryString = CategoriesListToString(categories);

			//Debug.Log("TESTT: " + CategoriesListToString(categories));
			// Check if the category already exists
			if (CategoryExists(true, categories))
			{
				//Debug.LogWarning("The category " + categoryString + " already exists. You may want to use CM_Debug.CategoryExists to check if the category already exists.");
				return;
			}

			categories = categoriesList.ToArray();

			string[] parentCategoryList = categories.Take(categories.Count() - 1).ToArray();
			Category parentCategory = GetCategory(parentCategoryList);

			// Check if the parent category exists
			if (!parentCategory)
			{
				//Debug.LogWarning("Can't add the category " + categoryString + " because the parent category does not exist.");
				return;
			}

			parentCategory.InnerCategory.Add(categories[categories.Length - 1], new Category(categories[categories.Length - 1], value));
		}

		public static void SetCategory(string category, bool value)
		{
			if (mainCategory == null)
				Initialize();

			// Check if the category already exists
			if (!CategoryExists(category))
			{
				//Debug.LogWarning("Tried setting " + category + " to " + value + ". The category does not exist.");
				return;
			}

			mainCategory.InnerCategory[defaultCategoryName].InnerCategory[category].Active = value;
		}

		public static bool CategoryExists(params string[] categories)
		{
			if (mainCategory == null)
				Initialize();

			Category category = mainCategory;

			for (int i = 0; i < categories.Length; i++)
			{
				if (category.InnerCategory.ContainsKey(categories[i]))
				{
					category = category.InnerCategory[categories[i]];
				}
				else
				{
					return false;
				}
			}

			return true;
		}

		public static bool CategoryExists(bool automaticlyAddCategories, params string[] categories)
		{
			if (mainCategory == null)
				Initialize();

			Category category = mainCategory;
			bool categoryExists = true;

			for (int i = 0; i < categories.Length; i++)
			{
				if (category.InnerCategory.ContainsKey(categories[i]))
				{
					category = category.InnerCategory[categories[i]];
				}
				else
				{
					categoryExists = false;
					category.InnerCategory.Add(categories[i], new Category(categories[i], false));
					category = category.InnerCategory[categories[i]];
				}
			}

			return categoryExists;
		}

		public static Category GetCategory(params string[] categories)
		{
			if (mainCategory == null)
				Initialize();

			Category category = mainCategory;

			for (int i = 0; i < categories.Length; i++)
			{
				if (category.InnerCategory.ContainsKey(categories[i]))
				{
					category = category.InnerCategory[categories[i]];
				}
				else
				{
					return null;
				}
			}

			return category;
		}

		public static string CategoriesListToString(string[] categories)
		{
			string categoryString = "";

			foreach (string category in categories)
			{
				categoryString += category + "/";
			}

			// Remove the last "/" character from the string
			categoryString = categoryString.Remove(categoryString.Length - 1);

			return categoryString;
		}
	}
}