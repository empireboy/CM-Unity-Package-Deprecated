using UnityEngine;

namespace CM.Shooting
{
	public class ShootModule : MonoBehaviour, IShoot
	{
		[SerializeField]
		private ShootingType _shootingType;

		[SerializeField]
		private Transform _shootTransform;

		[SerializeField]
		private GameObject _muzzle;

		private IShootProjectile _shootProjectileModule;

		private bool _isShooting = false;

		private ObjectPool _bulletPool;

		private ShootController _shootController;

		private void Awake()
		{
			_shootProjectileModule = GetComponent<IShootProjectile>();

			ObjectPool[] objectPools = FindObjectsOfType<ObjectPool>();

			foreach (ObjectPool objectPool in objectPools)
			{
				if (objectPool._P_PrefabGameObject == _shootingType.projectilePrefab)
				{
					_bulletPool = objectPool;
					break;
				}
			}
		}

		public void Shoot()
		{
			if (_shootController)
				return;

			ShootController shootController = ShootController.StartChecking(gameObject, _shootingType);

			if (!shootController)
				return;

			_shootController = shootController;

			_shootController.ShootEvent += OnShootChecked;

			_isShooting = true;
		}

		private void OnShootChecked()
		{
			// Shoot the projectile if it exists
			for (int i = 0; i < _shootingType.projectilesPerShot; i++)
			{
				GameObject projectile = _bulletPool.GetObject();

				if (projectile)
				{
					_shootProjectileModule.Shoot(projectile, _shootingType.shootForce, _shootingType.spray);
				}
			}

			// Instantiate Muzzle
			if (_muzzle)
			{
				GameObject muzzle = Instantiate(_muzzle, _shootTransform);
				Destroy(muzzle, 0.1f);
			}

			_isShooting = false;
		}

		public bool IsShooting()
		{
			return _isShooting;
		}
	}
}