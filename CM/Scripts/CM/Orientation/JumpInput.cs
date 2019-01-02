using UnityEngine;

namespace CM.Orientation
{
	public class JumpInput : MonoBehaviour
	{
		public string jumpKey = "Jump";

		private void Update()
		{
			if (Input.GetButtonDown(jumpKey))
				SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
		}
	}
}