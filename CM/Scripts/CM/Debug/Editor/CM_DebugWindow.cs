using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CM
{
	public class CM_DebugWindow : EditorWindow
	{
		private Vector2 _scrollPosition;

		[MenuItem("CM/Debug")]
		public static void ShowWindow()
		{
			GetWindow(typeof(CM_DebugWindow));
		}

		private void OnGUI()
		{
			GUILayout.Label("CM Debug", EditorStyles.boldLabel);

			EditorGUILayout.Space();

			// Initialize categories
			if (CM_Debug.mainCategory == null)
				return;

			// Copy categories from CM_Debug.mainCategory
			List<string> categoryKeys = new List<string>(CM_Debug.mainCategory.InnerCategory.Keys);

			// Draw a checkbox for every category
			foreach (string key in categoryKeys)
			{
				bool toggle = EditorGUILayout.BeginToggleGroup(key, CM_Debug.mainCategory.InnerCategory[key].Active);

				if (toggle != CM_Debug.mainCategory.InnerCategory[key].Active)
					CM_Debug.mainCategory.InnerCategory[key].Active = toggle;

				List<string> innerCategoryKeys = new List<string>(CM_Debug.mainCategory.InnerCategory[key].InnerCategory.Keys);

				// Draw a checkbox for every inner category
				foreach (var innerKey in innerCategoryKeys)
				{
					CM_Debug.mainCategory.InnerCategory[key].InnerCategory[innerKey].Active = EditorGUILayout.Toggle(
						innerKey, CM_Debug.mainCategory.InnerCategory[key].InnerCategory[innerKey].Active
					);
				}

				EditorGUILayout.EndToggleGroup();
			}

			// Warning messages
			if (CM_Debug.mainCategory.InnerCategory.Count == 0)
			{
				GUILayout.Label("No categories could be found.", EditorStyles.helpBox);
				EditorGUILayout.Space();
			}

			if (CM_Debug.mainCategory.InnerCategory.Count > 0)
			{
				EditorGUILayout.Space();
			}

			GUILayout.Label("Use CM_Debug.Log(category, message) to add a category.", EditorStyles.label);
			GUILayout.Label("You can also use CM_Debug.AddCategory(category, value).", EditorStyles.label);

			EditorGUILayout.Space();
		}
	}
}