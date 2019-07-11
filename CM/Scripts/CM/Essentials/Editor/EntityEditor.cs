using CM.Essentials;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Entity), true)]
public class EntityEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		Debug.Log("test");

		Entity entity = (Entity)target;

		if (GUILayout.Button("Create Modules"))
		{
			entity.CreateModules();
		}
	}
}