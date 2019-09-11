using UnityEngine;

namespace CM.Essentials.Timing
{
	[System.Serializable]
	public struct TimeData
	{
		[SerializeField]
		private float seconds;
		[SerializeField]
		private float minutes;
		[SerializeField]
		private float hours;

		public float Seconds
		{
			get
			{
				return seconds;
			}

			set
			{
				seconds = value;

				TimeLogic();
			}
		}
		public float Minutes
		{
			get
			{
				return minutes;
			}

			set
			{
				minutes = value;

				TimeLogic();
			}
		}
		public float Hours
		{
			get
			{
				return hours;
			}

			set
			{
				hours = value;

				TimeLogic();
			}
		}

		public float TotalSeconds
		{
			get
			{
				return Seconds + Minutes * 60 + Hours * 60;
			}
		}

		private void TimeLogic()
		{
			while (seconds >= 60f)
			{
				minutes++;
				seconds -= 60f;
			}

			while (minutes >= 60f)
			{
				minutes -= 60f;
				hours++;
			}
		}

		public static TimeData operator -(TimeData a, TimeData b)
		{
			TimeData timeData = new TimeData();

			float totalSeconds = a.TotalSeconds - b.TotalSeconds;

			if (totalSeconds < 0f)
				totalSeconds = 0f;

			timeData.Seconds = totalSeconds;

			while (timeData.Seconds >= 60f)
			{
				timeData.Minutes++;
				timeData.Seconds -= 60f;
			}

			return timeData;
		}

		public static TimeData operator +(TimeData a, float b)
		{
			TimeData timeData = new TimeData();

			float totalSeconds = a.TotalSeconds + b;

			if (totalSeconds < 0f)
				totalSeconds = 0f;

			timeData.Seconds = totalSeconds;

			while (timeData.Seconds >= 60f)
			{
				timeData.Minutes++;
				timeData.Seconds -= 60f;
			}

			return timeData;
		}

		public static TimeData operator -(TimeData a, float b)
		{
			TimeData timeData = new TimeData();

			float totalSeconds = a.TotalSeconds - b;

			if (totalSeconds < 0f)
				totalSeconds = 0f;

			timeData.Seconds = totalSeconds;

			while (timeData.Seconds >= 60f)
			{
				timeData.Minutes++;
				timeData.Seconds -= 60f;
			}

			return timeData;
		}

		public static float operator /(float a, TimeData b)
		{
			return a / b.TotalSeconds;
		}

		public static float operator /(TimeData a, float b)
		{
			return a.TotalSeconds / b;
		}

		public static bool operator <(float a, TimeData b)
		{
			return a < b.TotalSeconds;
		}

		public static bool operator >(float a, TimeData b)
		{
			return a > b.TotalSeconds;
		}

		public static bool operator <(TimeData a, float b)
		{
			return a.TotalSeconds < b;
		}

		public static bool operator >(TimeData a, float b)
		{
			return a.TotalSeconds > b;
		}

		public static bool operator <=(float a, TimeData b)
		{
			return a <= b.TotalSeconds;
		}

		public static bool operator >=(float a, TimeData b)
		{
			return a >= b.TotalSeconds;
		}

		public static bool operator <=(TimeData a, float b)
		{
			return a.TotalSeconds <= b;
		}

		public static bool operator >=(TimeData a, float b)
		{
			return a.TotalSeconds >= b;
		}
	}
}