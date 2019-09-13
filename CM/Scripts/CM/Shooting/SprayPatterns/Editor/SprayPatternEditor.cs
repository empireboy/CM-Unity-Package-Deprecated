using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CM.Shooting
{
	[CustomEditor(typeof(SprayPattern))]
	public class SprayPatternEditor : Editor
	{
		private float _scale = 10f;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			SprayPattern sprayPattern = (SprayPattern) target;

			GUI.backgroundColor = Color.gray;
			GUI.Box(new Rect(50, 120, 400, 400), "Spray Pattern Visualizer");

			for (int i = 0; i < sprayPattern.sprayPoints.Count; i++)
			{
				EditorGUI.DrawRect(new Rect(50 + 400 / 2 + sprayPattern.sprayPoints[i].x * _scale, 120 + 400 / 2 + sprayPattern.sprayPoints[i].y * _scale, 10, 10), Color.black);
			}
		}
	}
}