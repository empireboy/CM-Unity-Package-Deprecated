using UnityEngine;

namespace CM.Music
{
	public abstract class MusicLevelEditorBeatHandler : MonoBehaviour
	{
		protected MusicLevelEditor musicLevelEditor;

		private void Awake()
		{
			musicLevelEditor = FindObjectOfType<MusicLevelEditor>();
			OnAwake();
		}

		private void Start()
		{
			musicLevelEditor.ChangeIndexEvent += OnChangeIndex;
			OnStart();
		}

		protected void Release()
		{
			ReleaseBeatEvent();
		}

		private void ReleaseBeatEvent()
		{
			musicLevelEditor.ChangeIndexEvent -= OnChangeIndex;
		}

		protected abstract void OnChangeIndex(int currentIndex);
		protected virtual void OnAwake() { }
		protected virtual void OnStart() { }
	}
}