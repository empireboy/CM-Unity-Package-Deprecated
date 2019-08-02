using UnityEngine;

namespace CM.Essentials.Events
{
	public class GameEventInvoker : MonoBehaviour
	{
		public GameEvent gameEventToInvoke;

		public void Execute()
		{
			gameEventToInvoke.Invoke();
		}
	}
}