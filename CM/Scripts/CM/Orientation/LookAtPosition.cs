using UnityEngine;

namespace CM.Orientation
{
	public class LookAtPosition : MonoBehaviour, IRotateTo
	{
		[SerializeField]
		Transform _lookingTransform;

		public void RotateTo(Vector3 position)
		{
			_lookingTransform.LookAt(position);
		}
	}
}