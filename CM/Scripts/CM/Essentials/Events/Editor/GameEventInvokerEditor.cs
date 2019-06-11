using UnityEditor;
using UnityEngine;

namespace CM.Essentials.Events
{
	[CustomEditor(typeof(GameEventInvoker))]
	public class GameEventInvokerEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			GameEventInvoker gameEventInvoker = (GameEventInvoker)target;
			if (GUILayout.Button("Execute"))
			{
				gameEventInvoker.Execute();
			}
		}
	}
}