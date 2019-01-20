using UnityEngine;

namespace CM.Music
{
	[RequireComponent(typeof(RhythmController))]
	public abstract class RhythmControllerBeatHandler : MonoBehaviour
	{
		protected RhythmController rhythmController;

		private void Awake()
		{
			rhythmController = GetComponent<RhythmController>();
			OnAwake();
		}

		private void Start()
		{
			rhythmController.BeatEvent += OnBeat;
			OnStart();
		}

		private void OnDestroy()
		{
			ReleaseBeatEvent();
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