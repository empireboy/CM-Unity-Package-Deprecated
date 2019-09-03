using UnityEngine;

namespace CM.Orientation
{
	public interface IRotateTo
	{
		void RotateTo(Vector3 position);
		Vector3 GetPosition();
	}
}