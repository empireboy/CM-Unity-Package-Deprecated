namespace CM.Music
{
	[System.Serializable]
	public class BeatItem<T> where T : struct
	{
		public bool changeItem;
		public T item;
	}
}