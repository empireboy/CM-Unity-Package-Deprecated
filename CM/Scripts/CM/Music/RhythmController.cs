using UnityEngine;

namespace CM.Music
{
	public class RhythmController : MonoBehaviour
	{
		private IRhythmLevel _level;
		public IRhythmLevel Level { get => _level; }

		public delegate void BeatHandler(int beat);
		public event BeatHandler BeatEvent;

		private int _currentBeat = 0;
		public int CurrentBeat { get => _currentBeat; }

		private int _totalBeats = 0;
		public int TotalBeats { get => _totalBeats; }

		private float _secondsPerBeat;
		public float SecondsPerBeat { get => _secondsPerBeat; }

		private void NextBeat()
		{
			BeatEvent?.Invoke(_currentBeat);

			_currentBeat++;
		}

		public void SetMusicLevel(IRhythmLevel musicLevel)
		{
			_level = musicLevel;
			_secondsPerBeat = 60f / _level.Bpm;
			_totalBeats = Mathf.FloorToInt(_level.AudioData.clip.length / 0.25f / _secondsPerBeat);
			//StartLevel();
		}

		public void StartLevel()
		{
			if (!CanStartLevel())
				return;

			InvokeRepeating("NextBeat", 0, _secondsPerBeat * 0.25f);
		}

		public void StartLevelAt(int beat)
		{
			if (!CanStartLevel())
				return;

			_currentBeat = beat;
			InvokeRepeating("NextBeat", 0, _secondsPerBeat * 0.25f);
		}

		public void StopLevel()
		{
			if (!CanStopLevel())
				return;

			CancelInvoke("NextBeat");
		}

		protected bool CanStartLevel()
		{
			if (_level == null)
			{
				Debug.LogWarning("Can't start music level because there is no music level assigned");
				return false;
			}

			if (IsInvoking("NextBeat"))
			{
				Debug.LogWarning("This music level has already been started");
				return false;
			}

			return true;
		}

		protected bool CanStopLevel()
		{
			if (_level == null)
			{
				Debug.LogWarning("Can't stop music level because there is no music level assigned");
				return false;
			}

			if (!IsInvoking("NextBeat"))
			{
				Debug.LogWarning("Can't stop because this music level has not been started");
				return false;
			}

			return true;
		}

		public void SetCurrentBeat(int beat)
		{
			_currentBeat = beat;
			BeatEvent?.Invoke(beat);
		}

		public void AddTotalBeats(int beats)
		{
			_totalBeats += beats;
		}
	}
}