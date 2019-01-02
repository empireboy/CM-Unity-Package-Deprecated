using UnityEngine;

namespace CM.Shooter
{
	public class Ammo : MonoBehaviour
	{
		[SerializeField] private float _clipSize = 25;
		[SerializeField] private float _clips = 5;

		private float _currentClipSize;
		public float CurrentClipSize
		{
			get
			{
				return _currentClipSize;
			}
		}

		private float _currentClips;
		public float CurrentClips
		{
			get
			{
				return _currentClips;
			}
		}

		public float ClipSize
		{
			get
			{
				return _clipSize;
			}
		}
		public float Clips
		{
			get
			{
				return _clips;
			}
		}

		private void Start()
		{
			_currentClipSize = ClipSize;
			_currentClips = _clips;
		}

		public void ReduceClipSize()
		{
			_currentClipSize--;
		}

		public void Reload()
		{
			if (_currentClips > 0)
			{
				_currentClips--;
				_currentClipSize = ClipSize;
			}
		}
	}
}