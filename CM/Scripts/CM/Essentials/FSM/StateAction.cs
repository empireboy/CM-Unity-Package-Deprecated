using UnityEngine;

namespace CM.Essentials.FSM
{
	public abstract class StateAction : MonoBehaviour
	{
		public virtual void Enter() { }
		public virtual void Leave() { }

		public abstract void ActionUpdate();
	}
}