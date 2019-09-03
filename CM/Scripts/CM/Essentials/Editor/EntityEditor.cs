using CM.Essentials;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Entity), true)]
public class EntityEditor : Editor
{
	private float _spaceSize = 20f;

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		// Only run in Editor mode while not playing
		if (Application.isPlaying)
			return;

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
			return;

		GUILayout.Space(_spaceSize);

		// Found Modules
		int modulesFoundNumber = 0;

		for (int i = 0; i < entity.ModuleInterfaces.Length; i++)
		{
			Component[] modules = entity.GetModules(entity.ModuleInterfaces[i]);

			if (modules != null)
			{
				foreach (Component module in modules)
				{
					GUILayout.Label(module.ToString());
					modulesFoundNumber++;
				}
			}
		}

		// Display a Label with: "Modules Found (modulesFoundNumber)"
		GUILayout.Label("Modules Found " + "(" + modulesFoundNumber + ")", EditorStyles.boldLabel);
	}
}