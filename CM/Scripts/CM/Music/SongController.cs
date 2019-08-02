namespace CM.Music
{
	public class SongController : RhythmControllerBeatHandler
	{
		private AudioPlayer _audioPlayer;
		public AudioPlayer AudioPlayer { get => _audioPlayer; }

		public bool autoPlay = true;

		protected override void OnBeat(int currentBeat)
		{
			if (currentBeat == rhythmController.Level.BeatsBeforeLevelStarts)
			{
				if (_audioPlayer.AudioSource && !_audioPlayer.IsPlaying && autoPlay)
				{
					_audioPlayer.Play();
				}
				Release();
			}
		}

		public void SetAudio(IRhythmLevel musicLevel)
		{
			if (!_audioPlayer)
				_audioPlayer = gameObject.AddComponent<AudioPlayer>();

			_audioPlayer.SetAudio(musicLevel.AudioData);
		}

		public static float GetSongTime(int beatIndex)
		{
			RhythmController rhythmController = FindObjectOfType<RhythmController>();
			return rhythmController.SecondsPerBeat * 0.25f * (beatIndex - rhythmController.Level.BeatsBeforeLevelStarts);
		}
	}
}