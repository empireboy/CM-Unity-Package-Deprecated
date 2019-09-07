using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
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
			GUILayout.Label("Categories", EditorStyles.boldLabel);

			EditorGUILayout.Space();

			// Generate categories in play mode
			if (Application.isPlaying)
			{
				// Copy categories from CM_Debug.categories
				Dictionary<string, bool> categories = new Dictionary<string, bool>();
				categories = CM_Debug.categories;
				List<string> keys = new List<string>(categories.Keys);

				// Draw a checkbox for every category
				foreach (var key in keys)
				{
					categories[key] = EditorGUILayout.Toggle(key, categories[key]);
				}
			}

			// Warning messages
			if (Application.isPlaying && CM_Debug.categories.Count == 0)
			{
				GUILayout.Label("No categories could be found.", EditorStyles.helpBox);
				EditorGUILayout.Space();
			}

			if (!Application.isPlaying || CM_Debug.categories.Count == 0)
			{
				GUILayout.Label("Use CM_Debug.Log(category, message) to add a category.", EditorStyles.label);
				GUILayout.Label("Categories will generate in play mode.", EditorStyles.label);
			}

			EditorGUILayout.Space();
		}
	}
}
#endif