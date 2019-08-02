using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials.Events
{
	[CreateAssetMenu(menuName = "CM/Essentials/GameEvent")]
	public class GameEvent : ScriptableObject
	{
		private List<GameEventListener> _listeners = new List<GameEventListener>();

		public void Invoke()
		{
			for (int i = _listeners.Count - 1; i >= 0; i--)
			{
				_listeners[i].OnEventInvoked();
			}
		}

		public void AddListener(GameEventListener listener)
		{
			_listeners.Add(listener);
		}

		public void RemoveListener(GameEventListener listener)
		{
			_listeners.Remove(listener);
		}
	}
}