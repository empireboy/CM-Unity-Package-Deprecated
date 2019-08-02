namespace CM.Music
{
	public interface IRhythmLevel
	{
		int Bpm { get; }
		int BeatsBeforeLevelStarts { get; }
		AudioData AudioData { get; }
	}
}