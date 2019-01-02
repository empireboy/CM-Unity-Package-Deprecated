using UnityEngine;

namespace CM.Essentials.FSM
{
	public abstract class StateCondition : MonoBehaviour
	{
		public string nextStateName = "DefaultState";

		public virtual void Enter() { }
		public virtual void Leave() { }

		public abstract bool Condition();

		protected void ChangeState()
		{
			GetComponentInParent<StateMachine>().ChangeState(nextStateName);
		}
	}
}