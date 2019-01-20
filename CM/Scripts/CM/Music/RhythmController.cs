using UnityEngine;

namespace CM.Music
{
	public class RhythmController : MonoBehaviour
	{
		private IMusicLevel _level;
		public IMusicLevel Level { get => _level; }

		public delegate void BeatHandler(int beat);
		public event BeatHandler BeatEvent;

		private int _currentBeat = 0;
		public int CurrentBeat { get => _currentBeat; }

		private float _secondsPerBeat;
		public float SecondsPerBeat { get => _secondsPerBeat; }

		private void NextBeat()
		{
			BeatEvent?.Invoke(_currentBeat);

			_currentBeat++;
		}

		public void SetMusicLevel(IMusicLevel musicLevel)
		{
			_level = musicLevel;
			_secondsPerBeat = 60f / _level.GetBpm();
			StartLevel();
		}

		public void StartLevel()
		{
			if (_level == null)
			{
				Debug.LogWarning("Can't start music level because there is no music level assigned");
				return;
			}

			if (IsInvoking("NextBeat"))
			{
				Debug.LogWarning("This music level has already been started");
				return;
			}

			InvokeRepeating("NextBeat", 0, _secondsPerBeat * 0.25f);
		}
	}
}