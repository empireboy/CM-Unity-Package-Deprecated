using CM.Essentials.Interpolation;
using CM.Essentials.Timing;
using UnityEngine;

namespace CM.Orientation
{
	public class FlipTransformSmooth : FlipTransform, IFlip
	{
		public InterpolationType interpolationType;
		public TimeData flipTime;

		private TimeInterpolationFloat _timeInterpolationFloat = null;

		protected override void OnFlip(bool flip)
		{
			if (_timeInterpolationFloat)
				Destroy(_timeInterpolationFloat);

			switch (flip)
			{
				case true:
					_timeInterpolationFloat = TimeInterpolationFloat.InterpolateTo(gameObject, 0, 180, flipTime, OnFlipFinish);
					break;
				case false:
					_timeInterpolationFloat = TimeInterpolationFloat.InterpolateTo(gameObject, 180, 0, flipTime, OnFlipFinish);
					break;

			}

			_timeInterpolationFloat.interpolationType = interpolationType;
		}

		private void Update()
		{
			if (_timeInterpolationFloat)
				flipTransform.eulerAngles = new Vector3(flipTransform.eulerAngles.x, _timeInterpolationFloat.Value, flipTransform.eulerAngles.z);
		}
	}
}