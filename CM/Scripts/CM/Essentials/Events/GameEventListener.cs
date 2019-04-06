using UnityEngine;
using UnityEngine.Events;

namespace CM.Essentials.Events
{
	public class GameEventListener : MonoBehaviour
	{
		public GameEvent Event;
		public UnityEvent Response;

		private void OnEnable()
		{
			Event.AddListener(this);
		}

		private void OnDisable()
		{
			Event.RemoveListener(this);
		}

		public void OnEventInvoked()
		{
			Response.Invoke();
		}
	}
}