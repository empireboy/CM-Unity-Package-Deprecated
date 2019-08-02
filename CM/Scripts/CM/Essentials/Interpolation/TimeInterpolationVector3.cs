using CM.Essentials.Timing;
using System;
using UnityEngine;

namespace CM.Essentials.Interpolation
{
	public class TimeInterpolationVector3 : TimeInterpolation<Vector3>
	{
		protected override Vector3 GetCurrentValue()
		{
			return Vector3.Lerp(startInterpolation, TargetInterpolation, currentTime / totalTime);
		}

		public static TimeInterpolationVector3 InterpolateTo(GameObject addComponentAt, Vector3 startInterpolation, Vector3 targetInterpolation, TimeData time, Action callback)
		{
			TimeInterpolationVector3 timeInterpolation = addComponentAt.AddComponent<TimeInterpolationVector3>();
			timeInterpolation.InterpolateTo(startInterpolation, targetInterpolation, time, callback, true);

			return timeInterpolation;
		}
	}
}