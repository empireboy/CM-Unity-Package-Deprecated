using UnityEngine;

namespace CM.Essentials.Triggers
{
	public class Trigger3D : Trigger
	{
		private void OnTriggerEnter(Collider collision)
		{
			ExecuteTriggerEnter();
		}

		private void OnTriggerExit(Collider collision)
		{
			ExecuteTriggerLeave();
		}

		private void OnTriggerStay(Collider collision)
		{
			ExecuteTrigger();
		}
	}
}
