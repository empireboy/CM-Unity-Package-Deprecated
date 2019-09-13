using System.Collections.Generic;
using UnityEngine;

namespace CM.Shooting
{
	[CreateAssetMenu(menuName = "CM/Shooting/SprayPattern", order = 2)]
	public class SprayPattern : ScriptableObject
	{
		public List<Vector2> sprayPoints = new List<Vector2>();
	}
}