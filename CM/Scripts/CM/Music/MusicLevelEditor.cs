using UnityEngine;

namespace CM.Music
{
	public class MusicLevelEditor : MonoBehaviour
	{
		private int _currentIndex = 0;
		private int _indexIncreaseValue = 1;

		public delegate void ChangeIndexHandler(int index);
		public event ChangeIndexHandler ChangeIndexEvent;

		private void Update()
		{
			_indexIncreaseValue = (Input.GetKey(KeyCode.LeftShift)) ? 5 : 1;

			if (Input.GetAxis("Mouse ScrollWheel") < 0)
			{
				_currentIndex = Mathf.Max(0, _currentIndex + _indexIncreaseValue);
				UpdateIndex();
			}

			if (Input.GetAxis("Mouse ScrollWheel") > 0)
			{
				_currentIndex = Mathf.Max(0, _currentIndex - _indexIncreaseValue);
				UpdateIndex();
			}
		}

		public void UpdateIndex()
		{
			ChangeIndexEvent?.Invoke(_currentIndex);
		}

		public void UpdateIndex(int index)
		{
			_currentIndex = index;
			ChangeIndexEvent?.Invoke(index);
		}
	}
}