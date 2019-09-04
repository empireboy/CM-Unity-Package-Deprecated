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
			switch (flip)
			{
				case true:
					_timeInterpolationFloat = TimeInterpolationFloat.InterpolateTo(gameObject, 0, 180, flipTime, null);
					break;
				case false:
					_timeInterpolationFloat = TimeInterpolationFloat.InterpolateTo(gameObject, 180, 0, flipTime, null);
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