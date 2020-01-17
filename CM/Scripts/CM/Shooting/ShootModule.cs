using UnityEngine;
using UnityEngine.Events;

namespace CM.Shooting
{
	public class ShootModule : MonoBehaviour, IShoot
	{
		[SerializeField]
		private ShootingType _shootingType;
		public ShootingType ShootingType => _shootingType;

		[SerializeField]
		private Transform _shootTransform;

		[SerializeField]
		private GameObject _muzzle;

		[SerializeField]
		private float _muzzleLifetime = 0.1f;

		[SerializeField]
		private float _damage;

		[SerializeField]
		private GameObject _projectile;

		private IShootProjectile _shootProjectileModule;

		private bool _isShooting = false;
		private bool _canShoot = true;

		private ObjectPoolHandler _bulletPool;

		private ShootController _shootController;

		public UnityEvent onShoot;

		private void Awake()
		{
			_shootProjectileModule = GetComponent<IShootProjectile>();

			if (!_projectile)
				return;

			_bulletPool = FindBulletPool();
		}

		public void Shoot()
		{
			if (!gameObject.activeInHierarchy)
				return;

			if (_shootController)
				return;

			ShootController shootController = ShootController.StartChecking(gameObject, _shootingType);

			if (!shootController)
				return;

			_shootController = shootController;

			_shootController.ShootEvent += OnShootChecked;

			_isShooting = true;

			if (_canShoot)
				SpawnProjectile();

			_canShoot = false;
		}

		private void SpawnProjectile()
		{
			// Shoot the projectile if it exists
			if (_projectile)
			{
				for (int i = 0; i < _shootingType.projectilesPerShot; i++)
				{
					GameObject projectile = _bulletPool.GetObject(_projectile);

					if (projectile)
					{
						if (_shootProjectileModule == null)
						{
							CM_Debug.LogError("CM.Shooting", "There is a Bullet attached to " + this + ", but there is no script attached to shoot it.");
							return;
						}

						_shootProjectileModule.Shoot(projectile, _shootingType.shootForce, _shootingType.spray, _damage);
					}
				}
			}
			else if (_shootProjectileModule != null)
			{
				_shootProjectileModule.Shoot(null, _shootingType.shootForce, _shootingType.spray, _damage);
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

		private void OnShootChecked()
		{
			_canShoot = true;
		}

		public ObjectPoolHandler FindBulletPool()
		{
			ObjectPoolHandler objectPoolHandler = FindObjectOfType<ObjectPoolHandler>();

			if (objectPoolHandler)
				return objectPoolHandler;

			Debug.LogError("Could not find the Bullet Pool from the " + _projectile + " prefab.");

			return null;
		}

		public bool IsShooting()
		{
			return _isShooting;
		}

		public void SetDamage(float damage)
		{
			_damage = damage;
		}

		public void SetMuzzle(GameObject muzzle)
		{
			_muzzle = muzzle;
		}

		public void SetShootingType(ShootingType shootingType)
		{
			_shootingType = shootingType;
		}

		public void SetProjectile(GameObject projectile)
		{
			_projectile = projectile;
		}
	}
}