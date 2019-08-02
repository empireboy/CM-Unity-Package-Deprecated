using UnityEngine;
using NaughtyAttributes;

namespace CM.Orientation
{
	public class TransformLock : MonoBehaviour
	{
		[SerializeField] private TransformLockData _transformLockData;

		[Header("Sway Transform")]
		[SerializeField] private bool _sway = false;
		[ShowIf("_sway")]
		public Vector2 swayAmount = new Vector2(0.02f, 0.02f);
		[ShowIf("_sway")]
		public Vector2 maxSwayAmount = new Vector2(0.05f, 0.05f);

		private Vector3 _targetPositionStart;
		private Vector3 _targetRotationStart;

		private Vector3 _targetPositionRandom;
		private Vector3 _targetRotationRandom;

		private Vector3 _currentRandomPosition = Vector3.zero;
		private Vector3 _currentRandomRotation = Vector3.zero;

		private void Start()
		{
			_targetPositionStart = _transformLockData.TargetPosition;
			_targetRotationStart = _transformLockData.TargetRotation;
		}

		private void Update()
		{
			Vector3 swayPosition = Vector3.zero;

			if (_sway)
			{
				float swayX = -Input.GetAxis("Mouse X") * swayAmount.x;
				float swayY = -Input.GetAxis("Mouse Y") * swayAmount.y;
				swayX = Mathf.Clamp(swayX, -maxSwayAmount.x, maxSwayAmount.x);
				swayY = Mathf.Clamp(swayY, -maxSwayAmount.y, maxSwayAmount.y);
				swayPosition = new Vector3(swayX, swayY, 0);
			}

			_currentRandomPosition = Vector3.Lerp(_currentRandomPosition, _targetPositionRandom, Time.deltaTime * _transformLockData.RandomPositionSpeed);
			_currentRandomRotation = Vector3.Lerp(_currentRandomRotation, _targetRotationRandom, Time.deltaTime * _transformLockData.RandomRotationSpeed);

			transform.localPosition = Vector3.Lerp(transform.localPosition, _transformLockData.TargetPosition + swayPosition + _currentRandomPosition, Time.deltaTime * _transformLockData.PositionSpeed);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_transformLockData.TargetRotation + _targetRotationRandom), Time.deltaTime * _transformLockData.RotationSpeed);
		}

		public void Set(TransformLockData transformLockData)
		{
			_transformLockData = transformLockData;
		}

		public void SetPosition(Vector3 position)
		{
			_transformLockData.TargetPosition = position;
		}

		public void SetRotation(Vector3 rotation)
		{
			_transformLockData.TargetRotation = rotation;
		}

		public void ResetPosition()
		{
			_transformLockData.TargetPosition = _targetPositionStart;
		}

		public void ResetRotation()
		{
			_transformLockData.TargetRotation = _targetRotationStart;
		}

		public void ResetTransform()
		{
			ResetPosition();
			ResetRotation();
		}

		public void Sway(bool sway)
		{
			_sway = sway;
		}

		public void UpdateRandomTransform()
		{
			_targetPositionRandom = new Vector3(
				Random.Range(-_transformLockData.TargetPositionRandomizer.x, _transformLockData.TargetPositionRandomizer.x),
				Random.Range(-_transformLockData.TargetPositionRandomizer.y, _transformLockData.TargetPositionRandomizer.y),
				Random.Range(-_transformLockData.TargetPositionRandomizer.z, _transformLockData.TargetPositionRandomizer.z)
			);
			_targetRotationRandom = new Vector3(
				Random.Range(-_transformLockData.TargetRotationRandomizer.x, _transformLockData.TargetRotationRandomizer.x),
				Random.Range(-_transformLockData.TargetRotationRandomizer.y, _transformLockData.TargetRotationRandomizer.y),
				Random.Range(-_transformLockData.TargetRotationRandomizer.z, _transformLockData.TargetRotationRandomizer.z)
			);
		}

		public void ResetRandomizer()
		{
			_targetPositionRandom = Vector3.zero;
			_targetRotationRandom = Vector3.zero;
		}
	}

	[System.Serializable]
	public struct TransformLockData
	{
		public float PositionSpeed;
		public float RotationSpeed;
		public Vector3 TargetPosition;
		public Vector3 TargetRotation;
		public Vector3 TargetPositionRandomizer;
		public Vector3 TargetRotationRandomizer;
		public float RandomPositionSpeed;
		public float RandomRotationSpeed;
	}
}
