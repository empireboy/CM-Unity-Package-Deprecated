using UnityEngine;
using UnityEngine.Events;

namespace CM.Shooting
{
	public class TriggerModule : MonoBehaviour, IGunTrigger
	{
		[SerializeField]
		private GunTriggerState _state = GunTriggerState.None;

		[SerializeField]
		private GameObject _shootModuleObject;

		private IShoot _shootModule;

		public UnityEvent triggerLockedEvent;
		public UnityEvent triggerPulledEvent;

		private void Awake()
		{
			_shootModule = _shootModuleObject.GetComponent<IShoot>();
		}

		public void SetTriggerState(GunTriggerState state)
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