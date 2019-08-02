using UnityEngine;

namespace CM.Orientation
{
	public class GroundChecker : GroundCheckerBase
	{
		public float groundDistance = 0.2f;

		private void Update()
		{
			isGrounded = Physics.CheckSphere(transform.position, groundDistance, ground, QueryTriggerInteraction.Ignore);
		}
	}
}