using CM.Essentials.Timing;
using System;
using UnityEngine;

namespace CM.Essentials.Interpolation
{
	public class TimeInterpolationFloat : TimeInterpolation<float>
	{
		public InterpolationType interpolationType;

		protected override float GetCurrentValue()
		{
			float value = 0.0f;

			Easing.Function interpolationMethod = Easing.GetEasingFunction(interpolationType);
			value = interpolationMethod(startInterpolation, TargetInterpolation, currentTime / totalTime);

			return value;
		}

		public static TimeInterpolationFloat InterpolateTo(GameObject addComponentAt, float startInterpolation, float targetInterpolation, TimeData time, Action callback)
		{
			TimeInterpolationFloat timeInterpolation = addComponentAt.AddComponent<TimeInterpolationFloat>();
			timeInterpolation.InterpolateTo(startInterpolation, targetInterpolation, time, callback, true);

			return timeInterpolation;
		}

		public static TimeInterpolationFloat InterpolateTo(GameObject addComponentAt, float startInterpolation, float targetInterpolation, TimeData time, Action callback, InterpolationType interpolationType)
		{
			TimeInterpolationFloat timeInterpolation = addComponentAt.AddComponent<TimeInterpolationFloat>();
			timeInterpolation.interpolationType = interpolationType;
			timeInterpolation.InterpolateTo(startInterpolation, targetInterpolation, time, callback, true);

			return timeInterpolation;
		}
	}
}