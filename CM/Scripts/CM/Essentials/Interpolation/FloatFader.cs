using CM.Essentials.Timing;
using UnityEngine;

namespace CM.Essentials.Interpolation
{
	public abstract class FloatFader<T> : MonoBehaviour where T : Component
	{
		public InterpolationType interpolationType;
		public TimeData fadeInTime;
		public TimeData fadeOutTime;
		public float minValue = 0;
		public float maxValue = 1;

		protected T component;

		private TimeInterpolationFloat _timeInterpolationFloat;

		private void Awake()
		{
			component = GetComponent<T>();
		}

		public virtual void FadeIn()
		{
			float currentComponentValue = GetComponentValue();

			_timeInterpolationFloat = TimeInterpolationFloat.InterpolateTo(gameObject, currentComponentValue, maxValue, fadeInTime, OnFadeInFinish, interpolationType);
		}

		public virtual void FadeOut()
		{
			float currentComponentValue = GetComponentValue();

			_timeInterpolationFloat = TimeInterpolationFloat.InterpolateTo(gameObject, currentComponentValue, minValue, fadeOutTime, OnFadeOutFinish, interpolationType);
		}

		protected abstract float GetComponentValue();
		protected abstract void SetComponentValue(float value);

		protected virtual void OnFadeInFinish() { }
		protected virtual void OnFadeOutFinish() { }

		private void Update()
		{
			if (_timeInterpolationFloat)
			{
				SetComponentValue(_timeInterpolationFloat.Value);
			}
		}
	}
}