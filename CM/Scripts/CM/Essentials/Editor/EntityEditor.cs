using CM;
using CM.Essentials;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Entity), true)]
public class EntityEditor : Editor
{
	private float _spaceSize = 20f;
	private bool[] _moduleFoldouts = new bool[0];

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		// Get the target entity
		Entity entity = (Entity)target;

		// Only run if there are modules created
		if (entity.ModuleInterfaces.Length == 0)
		{
			entity.InitializeModules();
			return;
		}

		// Found Modules
		List<Component> modules = new List<Component>();

		for (int i = 0; i < entity.ModuleInterfaces.Length; i++)
		{
			Component[] tmpModules = entity.GetModules(entity.ModuleInterfaces[i], true);

			foreach (Component module in tmpModules)
			{
				// Not including duplicates
				if (!modules.Contains(module))
					modules.Add(module);
			}
		}

		// Display a Label with: "Modules Found (modulesFoundNumber)"
		GUILayout.Label("Modules Found " + "(" + modules.Count + ")", EditorStyles.boldLabel);

		if (_moduleFoldouts.Length != modules.Count)
		{
			_moduleFoldouts = new bool[modules.Count];
		}

		for (int i = 0; i < modules.Count; i++)
		{
			Editor tmpEditor = CreateEditor(modules[i]);

			EditorGUILayout.BeginVertical("Box");

			EditorGUILayout.BeginHorizontal();

			// Foldouts
			GUIStyle foldoutStyle = new GUIStyle()
			{
				fontStyle = FontStyle.Bold,
				stretchWidth = true,
				stretchHeight = false,
				alignment = TextAnchor.MiddleLeft,
				margin = new RectOffset(20, 0, 0, 0)
			};
			_moduleFoldouts[i] = EditorGUILayout.Foldout(_moduleFoldouts[i], modules[i].ToString(), true, foldoutStyle);

			// Module activate GameObject checkbox
			if (modules[i].gameObject.name != "Modules")
			{
				modules[i].gameObject.SetActive(EditorGUILayout.Toggle(modules[i].gameObject.activeInHierarchy, GUILayout.ExpandWidth(true), GUILayout.Width(20), GUILayout.Height(20)));
			}

			EditorGUILayout.EndHorizontal();

			if (_moduleFoldouts[i])
			{
				EditorGUILayout.BeginVertical("Box");

				tmpEditor.OnInspectorGUI();

				EditorGUILayout.EndVertical();
			}

			EditorGUILayout.EndVertical();
		}

		EditorGUILayout.BeginHorizontal("Box");

		// Open all foldouts
		if (GUILayout.Button("Open All"))
		{
			CM_Debug.Log("Opening all foldouts", "CM", "CM.Entity");

			for (int i = 0; i < _moduleFoldouts.Length; i++)
				_moduleFoldouts[i] = true;
		}

		// Close all foldouts
		if (GUILayout.Button("Close All"))
		{
			CM_Debug.Log("Closing all foldouts", "CM", "CM.Entity");

			for (int i = 0; i < _moduleFoldouts.Length; i++)
				_moduleFoldouts[i] = false;
		}

		// Activate all Modules
		if (GUILayout.Button("Activate All"))
		{
			CM_Debug.Log("Activating all Modules", "CM", "CM.Entity");

			Transform[] childs = entity.GetModuleObject().GetComponentsInChildren<Transform>(true);

			for (int i = 0; i < childs.Length; i++)
			{
				childs[i].gameObject.SetActive(true);
			}
		}

		EditorGUILayout.EndHorizontal();
	}
}