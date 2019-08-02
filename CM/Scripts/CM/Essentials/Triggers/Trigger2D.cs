using UnityEngine;

namespace CM.Essentials.Triggers
{
	public class Trigger2D : Trigger
	{
		private void OnTriggerEnter2D(Collider2D collision)
		{
			ExecuteTriggerEnter();
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			ExecuteTriggerLeave();
		}

		private void OnTriggerStay2D(Collider2D collision)
		{
			ExecuteTrigger();
		}
	}
}
