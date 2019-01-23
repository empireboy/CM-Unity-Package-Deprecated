using UnityEngine;

namespace CM.Music
{
	public class MusicLevelEditor : MonoBehaviour
	{
		private int _currentIndex = 0;

		public delegate void ChangeIndexHandler(int index);
		public event ChangeIndexHandler ChangeIndexEvent;

		public bool isPlaying = false;

		private void Update()
		{
			if (isPlaying)
				return;

			if (Input.GetAxis("Mouse ScrollWheel") < 0)
			{
				_currentIndex = Mathf.Max(0, _currentIndex + 1);
				UpdateIndex();
			}

			if (Input.GetAxis("Mouse ScrollWheel") > 0)
			{
				_currentIndex = Mathf.Max(0, _currentIndex - 1);
				UpdateIndex();
			}
		}

		public void UpdateIndex()
		{
			ChangeIndexEvent?.Invoke(_currentIndex);
		}
	}
}