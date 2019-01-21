using UnityEngine;

namespace CM.Music
{
	public class MusicLevelEditor : MonoBehaviour
	{
		private int _currentIndex = 0;

		public delegate void ChangeIndexHandler(int index);
		public event ChangeIndexHandler ChangeIndexEvent;

		private void Update()
		{
			if (Input.GetButtonDown("MusicLevelEditor Next"))
			{
				_currentIndex = Mathf.Max(0, _currentIndex + 1);
				UpdateIndex();
			}

			if (Input.GetButtonDown("MusicLevelEditor Previous"))
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