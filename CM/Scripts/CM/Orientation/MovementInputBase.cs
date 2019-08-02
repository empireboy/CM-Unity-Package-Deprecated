using UnityEngine;

namespace CM.Orientation
{
	public abstract class MovementInputBase : MonoBehaviour
	{
		public string horizontalAxis = "Horizontal";
		public string verticalAxis = "Vertical";

		protected Vector3 inputs;

		public Vector3 GetInput()
		{
			return inputs;
		}
	}
}