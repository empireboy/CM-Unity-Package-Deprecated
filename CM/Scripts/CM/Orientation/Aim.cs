using UnityEngine;
using UnityEngine.Events;

namespace CM.Orientation
{
	public class Aim : MonoBehaviour
	{
		[SerializeField] private TransformLock _transformLock;
		[SerializeField] private TransformLockData _transformLockData;

		[SerializeField] private UnityEvent _onAimStart;
		[SerializeField] private UnityEvent _onAimStop;

		public string aimKey = "Aim";

		private bool _isAiming = false;
		public bool IsAiming
		{
			get
			{
				return _isAiming;
			}
		}

		private void Update()
		{
			if (Input.GetButtonDown(aimKey) || (Input.GetButton(aimKey) && !_isAiming))
				StartAim();

			if (Input.GetButtonUp(aimKey) || (!Input.GetButton(aimKey) && _isAiming))
				StopAim();
		}

		public void StartAim()
		{
			GetComponent<TransformLock>().Set(_transformLockData);

			_isAiming = true;

			_onAimStart.Invoke();
		}

		public void StopAim()
		{
			_isAiming = false;

			_onAimStop.Invoke();
		}
	}
}