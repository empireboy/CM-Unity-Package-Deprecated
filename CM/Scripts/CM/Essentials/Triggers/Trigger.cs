using UnityEngine;
using UnityEngine.Events;

namespace CM.Essentials.Triggers
{
	public abstract class Trigger : MonoBehaviour
	{
		public delegate void TriggerEnterHandler();
		public event TriggerEnterHandler TriggerEnterEvent;
		public delegate void TriggerLeaveHandler();
		public event TriggerLeaveHandler TriggerLeaveEvent;
		public delegate void TriggerHandler();
		public event TriggerHandler TriggerEvent;

		public UnityEvent OnTriggerEnterEvent;
		public UnityEvent OnTriggerLeaveEvent;
		public UnityEvent OnTriggerEvent;

		protected void ExecuteTriggerEnter()
		{
			TriggerEnterEvent?.Invoke();
			OnTriggerEnterEvent.Invoke();
		}

		protected void ExecuteTriggerLeave()
		{
			TriggerLeaveEvent?.Invoke();
			OnTriggerLeaveEvent.Invoke();
		}

		protected void ExecuteTrigger()
		{
			TriggerEvent?.Invoke();
			OnTriggerEvent.Invoke();
		}
	}
}
