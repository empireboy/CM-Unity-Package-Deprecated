using CM.Essentials.Timing;
using UnityEngine;

namespace CM.Orientation
{
	public class InterpolateToPosition : MonoBehaviour
	{
		private Vector3 _targetPosition;
		public Vector3 TargetPosition { get => _targetPosition; }
		private Vector3 _startPosition;
		public Vector3 StartPosition { get => _startPosition; }

		private bool _isMoving = false;
		public bool IsMoving { get => _isMoving; }

		[SerializeField]
		private TimeData _time;
		private float _timer = 0.0f;

		public delegate void FinishedHandler();
		public event FinishedHandler FinishedEvent;

		private void Update()
		{
			if (!IsMoving)
				return;

			transform.position = Vector3.Lerp(StartPosition, TargetPosition, _timer / _time);
			if (_timer < _time)
			{
				_timer += Time.deltaTime;
			}
			else
			{
				FinishedEvent?.Invoke();
				_isMoving = false;
			}
		}

		public void MoveTo(Vector3 targetPosition)
		{
			_isMoving = true;
			_startPosition = transform.position;
			_targetPosition = targetPosition;
			_timer = 0.0f;
		}

		public void MoveTo(Vector3 targetPosition, TimeData time)
		{
			_time = time;
			MoveTo(targetPosition);
		}
	}
}