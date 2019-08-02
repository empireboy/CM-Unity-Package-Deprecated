using UnityEngine;

namespace CM.Music
{
	public abstract class RhythmControllerBeatHandler : MonoBehaviour
	{
		protected RhythmController rhythmController;

		private void Awake()
		{
			rhythmController = FindObjectOfType<RhythmController>();
			OnAwake();
		}

		private void Start()
		{
			rhythmController.BeatEvent += OnBeat;
			OnStart();
		}

		protected void Release()
		{
			ReleaseBeatEvent();
		}

		private void ReleaseBeatEvent()
		{
			rhythmController.BeatEvent -= OnBeat;
		}

		protected abstract void OnBeat(int currentBeat);
		protected virtual void OnAwake() { }
		protected virtual void OnStart() { }
	}
}