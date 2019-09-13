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

		// Entity Label
		GUILayout.Label("Modules", EditorStyles.boldLabel);

		// Create Modules
		if (GUILayout.Button("Create Modules"))
		{
			entity.CreateModules();
		}

		// Only run if there are modules created
		if (entity.ModuleInterfaces == null)
		{
			entity.InitializeModules();
			return;
		}

		GUILayout.Space(_spaceSize);

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
			_moduleFoldouts[i] = EditorGUILayout.Foldout(_moduleFoldouts[i], modules[i].ToString(), true, EditorStyles.foldout);

			if (_moduleFoldouts[i])
			{
				tmpEditor.OnInspectorGUI();
			}
		}
	}
}