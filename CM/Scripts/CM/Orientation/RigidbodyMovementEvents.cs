using UnityEngine.Events;
using UnityEngine;

namespace CM.Orientation
{
	public class RigidbodyMovementEvents : MonoBehaviour
	{
		/*
		[SerializeField] private UnityEvent _onMoveStart;
		[SerializeField] private UnityEvent _onMoveStop;

		private bool _isInputMagnitudeGettingBigger = false;
		private bool _isInputMagnitudeGettingSmaller = false;
		private float _previousInputMagnitude;

		private void Update()
		{
			_isInputMagnitudeGettingBigger = (inputs.magnitude > _previousInputMagnitude && !Mathf.Approximately(inputs.magnitude, _previousInputMagnitude) || inputs.magnitude >= 1);
			_isInputMagnitudeGettingSmaller = (inputs.magnitude < _previousInputMagnitude && !Mathf.Approximately(inputs.magnitude, _previousInputMagnitude) || inputs.magnitude <= 0);

			if (_isInputMagnitudeGettingBigger && !IsMoving)
				_onMoveStart.Invoke();

			if (_isInputMagnitudeGettingSmaller && IsMoving)
				_onMoveStop.Invoke();

			_previousInputMagnitude = inputs.magnitude;
		}
		*/
	}
}