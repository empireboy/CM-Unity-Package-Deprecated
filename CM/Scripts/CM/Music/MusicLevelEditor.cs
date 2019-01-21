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
				ChangeIndexEvent?.Invoke(_currentIndex);
			}

			if (Input.GetButtonDown("MusicLevelEditor Previous"))
			{
				_currentIndex = Mathf.Max(0, _currentIndex - 1);
				ChangeIndexEvent?.Invoke(_currentIndex);
			}
			Debug.Log(_currentIndex);
		}
	}
}