using CM.Essentials.Timing;
using System;
using UnityEngine;

namespace CM.Essentials.Interpolation
{
	public abstract class TimeInterpolation<T> : MonoBehaviour
	{
		protected T targetInterpolation;
		public T TargetInterpolation { get => targetInterpolation; }
		protected T startInterpolation;
		public T StartInterpolation { get => startInterpolation; }

		private bool _isMoving = false;
		public bool IsMoving { get => _isMoving; }

		protected TimeData totalTime;
		public TimeData TotalTime { get => totalTime; }

		protected float currentTime = 0.0f;
		public float CurrentTime { get => currentTime; }

		private T _value;
		public T Value { get => _value; }

		private bool _destroyOnFinish = true;

		public Action FinishedCallback;

		private bool _isLastFrame = false;

		private void Update()
		{
			if (!_isMoving)
				return;

			_value = GetCurrentValue();
			if (currentTime < totalTime)
			{
				currentTime += Time.deltaTime;
			}
			else
			{
				if (_destroyOnFinish && _isLastFrame)
					Destroy(this);

				if (_isLastFrame)
					_isMoving = false;

				if (_destroyOnFinish)
					_isLastFrame = true;

				if (!_isMoving)
					return;

				FinishedCallback?.Invoke();
				FinishedCallback = null;
			}
		}

		protected abstract T GetCurrentValue();

		public void InterpolateTo(T startInterpolation, T targetInterpolation, TimeData time, Action callback)
		{
			totalTime = time;
			_isMoving = true;
			this.startInterpolation = startInterpolation;
			this.targetInterpolation = targetInterpolation;
			_value = startInterpolation;
			currentTime = 0.0f;
			FinishedCallback += callback;
		}

		public void InterpolateTo(T startInterpolation, T targetInterpolation, TimeData time, Action callback, bool destroyOnFinish)
		{
			_destroyOnFinish = true;
			InterpolateTo(startInterpolation, targetInterpolation, time, callback);
		}
	}
}