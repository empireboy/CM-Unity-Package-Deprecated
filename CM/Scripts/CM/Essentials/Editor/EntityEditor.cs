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

		Entity entity = (Entity)target;

		// Create Modules
		if (GUILayout.Button("Create Modules"))
		{
			entity.CreateModules();
		}

		GUILayout.Space(_spaceSize);

		// Found Modules

	}
}