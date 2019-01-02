using UnityEngine;

namespace CM.Orientation
{
	public class MovementInput : MovementInputBase
	{
		private void Update()
		{
			inputs = Vector3.zero;
			inputs.x = Input.GetAxis(horizontalAxis);
			inputs.z = Input.GetAxis(verticalAxis);
		}
	}
}