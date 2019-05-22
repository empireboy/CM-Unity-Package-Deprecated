using UnityEngine;
using UnityEngine.Events;

namespace CM.Essentials
{
	public class Trigger2D : MonoBehaviour
	{
		public delegate void TriggerHandler();
		public event TriggerHandler TriggerEvent;

		public UnityEvent OnTrigger;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			TriggerEvent?.Invoke();
			OnTrigger.Invoke();
		}
	}
}
