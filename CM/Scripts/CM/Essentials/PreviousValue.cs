namespace CM
{
	public class PreviousValue<T> where T : struct
	{
		public T value;
		protected T previousValue;
		public T Previous
		{
			get
			{
				return previousValue;
			}
		}

		public PreviousValue()
		{
			UpdateCaller.AddUpdateCallback(OnValueUpdate);
		}

		private void OnValueUpdate()
		{
			previousValue = value;
		}
	}
}