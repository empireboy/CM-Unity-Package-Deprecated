using UnityEngine;
using CM.Orientation;

namespace CM.Shooter
{
	public class WeaponTransformLock : MonoBehaviour
	{
		[SerializeField] private TransformLock _weaponTransformLock;
		[SerializeField] private TransformLockData _weaponTransformLockData;

		private void Start()
		{
			transform.root.GetComponentInChildren<WeaponShoot>().OnShoot += OnShoot;

			_weaponTransformLock.Set(_weaponTransformLockData);
		}

		private void OnShoot()
		{
			_weaponTransformLock.UpdateRandomTransform();
		}

		public void SetTransformLock()
		{
			_weaponTransformLock.Set(_weaponTransformLockData);
		}

		public void OnResetTransformLockRandomizer()
		{
			_weaponTransformLock.ResetRandomizer();
		}
	}
}