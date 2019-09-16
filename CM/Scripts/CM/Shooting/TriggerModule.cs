using UnityEngine;
using UnityEngine.Events;

namespace CM.Shooting
{
	internal class TriggerModule : MonoBehaviour, IGunTrigger
	{
		private GunTriggerState _state = GunTriggerState.None;

		private IShoot _shootModule;

		public UnityEvent triggerLockedEvent;
		public UnityEvent triggerPulledEvent;

		private void Awake()
		{
			_shootModule = GetComponent<IShoot>();
		}

		public void SetState(GunTriggerState state)
		{
			_state = state;
		}

		public void Trigger()
		{
			switch (_state)
			{
				case GunTriggerState.Locked:
					triggerLockedEvent.Invoke();
					return;
				case GunTriggerState.None:
					triggerPulledEvent.Invoke();
					break;
			}

			_shootModule.Shoot();
		}
	}
}