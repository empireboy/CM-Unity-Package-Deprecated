using UnityEngine;

namespace CM.Orientation
{
	public abstract class GroundCheckerBase : MonoBehaviour
	{
		public LayerMask ground;

		protected bool isGrounded = true;
		public bool IsGrounded
		{
			get
			{
				return isGrounded;
			}
		}
	}
}