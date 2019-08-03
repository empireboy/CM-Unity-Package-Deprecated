using UnityEngine;

namespace CM.Orientation
{
	public class AxisRotator : MonoBehaviour, IRotate
	{
		[SerializeField]
		private Transform _transform;

		private enum AxisTypes { X, Y, Z };

		[SerializeField]
		private AxisTypes _axis;

		[SerializeField]
		private bool _inverted = false;

		[SerializeField]
		private bool _clamp = false;

		[Range(-360f, 359f)]
		public float clampMin = 0f;

		[Range(-360f, 359f)]
		public float clampMax = 359f;

		private Vector3 _rotation = Vector3.zero;

		public void Rotate(Vector3 input)
		{
			// Get the rotation
			switch (_axis)
			{
				case AxisTypes.X:

					// Add the input or inverted input to the rotation
					_rotation.y += (!_inverted) ? input.x : -input.x;

					// Clamp the rotation
					if (_clamp)
					{
						_rotation.y = Mathf.Clamp(_rotation.y, clampMin, clampMax);
					}

					break;
				case AxisTypes.Y:

					// Add the input or inverted input to the rotation
					_rotation.x += (!_inverted) ? input.y : -input.y;

					// Clamp the rotation
					if (_clamp)
					{
						_rotation.x = Mathf.Clamp(_rotation.x, clampMin, clampMax);
					}

					break;
				case AxisTypes.Z:

					// Add the input / inverted input to the rotation
					_rotation.z += (!_inverted) ? input.z : -input.z;

					// Clamp the rotation
					if (_clamp)
					{
						_rotation.z = Mathf.Clamp(_rotation.z, clampMin, clampMax);
					}

					break;
			}

			// Rotate
			_transform.localRotation = Quaternion.Euler(_rotation);
		}
	}
}