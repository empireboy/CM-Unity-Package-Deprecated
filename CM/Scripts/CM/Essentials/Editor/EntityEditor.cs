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
		if (entity.ModuleInterfaces == null)
		{
			entity.InitializeModules();
			return;
		}

		// Found Modules
		List<Component> modules = new List<Component>();

		for (int i = 0; i < entity.ModuleInterfaces.Length; i++)
		{
			modules.AddRange(entity.GetModules(entity.ModuleInterfaces[i]));
		}

		// Display a Label with: "Modules Found (modulesFoundNumber)"
		GUILayout.Label("Modules Found " + "(" + modules.Count + ")", EditorStyles.boldLabel);

		if (_moduleFoldouts.Length != modules.Count)
		{
			_moduleFoldouts = new bool[modules.Count];
		}

		for (int i = 0; i < modules.Count; i++)
		{
			//modules[i].hideFlags = HideFlags.None;

			Editor tmpEditor = CreateEditor(modules[i]);

			EditorGUILayout.BeginVertical("Box");

			GUIStyle style = new GUIStyle() {
				fontStyle = FontStyle.Bold,
				stretchWidth = true,
				stretchHeight = false,
				alignment = TextAnchor.MiddleLeft,
				margin = new RectOffset(30, 0, 0, 0)
			};
			_moduleFoldouts[i] = EditorGUILayout.Foldout(_moduleFoldouts[i], modules[i].ToString(), true, style);

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
			CM_Debug.Log("CM Entity", "Opening all foldouts");

			for (int i = 0; i < _moduleFoldouts.Length; i++)
				_moduleFoldouts[i] = true;
		}

		// Close all foldouts
		if (GUILayout.Button("Close All"))
		{
			CM_Debug.Log("CM Entity", "Closing all foldouts");

			for (int i = 0; i < _moduleFoldouts.Length; i++)
				_moduleFoldouts[i] = false;
		}

		// Hide Module object
		if (GUILayout.Button("Hide Modules"))
		{
			CM_Debug.Log("CM Entity", "Hiding all modules");

			entity.GetModuleObject().hideFlags = HideFlags.HideInInspector;
		}

		// Show Module object
		if (GUILayout.Button("Show Modules"))
		{
			CM_Debug.Log("CM Entity", "Showing all modules");

			entity.GetModuleObject().hideFlags = HideFlags.None;
		}

		EditorGUILayout.EndHorizontal();
	}
}