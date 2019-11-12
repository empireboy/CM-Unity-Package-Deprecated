using UnityEngine;
using UnityEngine.Events;

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

		[SerializeField]
		private float _muzzleLifetime = 0.1f;

		private IShootProjectile _shootProjectileModule;

		private bool _isShooting = false;

		private ObjectPool _bulletPool;

		private ShootController _shootController;

		public UnityEvent onShoot;

		private void Awake()
		{
			_shootProjectileModule = GetComponent<IShootProjectile>();

			if (!_shootingType.projectilePrefab)
				return;

			_bulletPool = FindBulletPool();
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
			if (_shootingType.projectilePrefab)
			{
				for (int i = 0; i < _shootingType.projectilesPerShot; i++)
				{
					GameObject projectile = _bulletPool.GetObject();

					if (projectile)
					{
						if (_shootProjectileModule == null)
						{
							CM_Debug.LogError("CM.Shooting", "There is a Bullet attached to " + this + ", but there is no script attached to shoot it.");
							return;
						}

						_shootProjectileModule.Shoot(projectile, _shootingType.shootForce, _shootingType.spray);
					}
				}
			}
			else if (_shootProjectileModule != null)
			{
				_shootProjectileModule.Shoot(_shootingType.shootForce, _shootingType.spray, _shootingType.nullProjectileDamage);
			}

			// Instantiate Muzzle
			if (_muzzle)
			{
				GameObject muzzle = Instantiate(_muzzle, _shootTransform);
				Destroy(muzzle, _muzzleLifetime);
			}

			// Shoot event
			onShoot.Invoke();

			_isShooting = false;
		}

		public ObjectPool FindBulletPool()
		{
			ObjectPool[] objectPools = FindObjectsOfType<ObjectPool>();

			// Look for the bullet pool
			foreach (ObjectPool objectPool in objectPools)
			{
				if (objectPool._P_PrefabGameObject == _shootingType.projectilePrefab)
				{
					return objectPool;
				}
			}

			Debug.LogError("Could not find the Bullet Pool from the " + _shootingType.projectilePrefab + " prefab.");

			return null;
		}

		public bool IsShooting()
		{
			return _isShooting;
		}
	}
}