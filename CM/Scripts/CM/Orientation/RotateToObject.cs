using UnityEngine;

namespace CM.Orientation
{
	public class RotateToObject : MonoBehaviour
	{
		public Transform target;

		private void Update()
		{
			// Get Angle in Radians
			float AngleRad = Mathf.Atan2(
				target.position.y - transform.position.y,
				target.position.x - transform.position.x
			);
			// Get Angle in Degrees
			float AngleDeg = (180 / Mathf.PI) * AngleRad;
			// Rotate Object
			transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
		}
	}
}