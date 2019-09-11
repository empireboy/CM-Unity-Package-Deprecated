using UnityEngine;

namespace CM.Shooting
{
	public class GunModule : MonoBehaviour, IShoot, IEquipGun
	{
		[SerializeField]
		private Gun _equippedGun;

		private IShootProjectile _shootProjectileModule;

		private bool _isShooting = false;

		private ObjectPool _bulletPool;

		private ShootController _shootController;

		private void Awake()
		{
			_shootProjectileModule = GetComponent<IShootProjectile>();
		}

		private void Start()
		{
			if (_equippedGun != null)
				EquipGun(_equippedGun);
		}

		public void EquipGun(Gun gun)
		{
			_equippedGun = gun;

			ObjectPool[] objectPools = FindObjectsOfType<ObjectPool>();

			for (int i = 0; i < objectPools.Length; i++)
			{
				if (objectPools[i]._P_PrefabGameObject == gun.projectile)
				{
					_bulletPool = objectPools[i];
					break;
				}
			}
		}

		public void Shoot()
		{
			_shootController = ShootController.StartChecking(gameObject, _equippedGun.shootingType);

			if (!_shootController)
				return;

			_shootController.ShootEvent += OnShootChecked;

			_isShooting = true;
		}

		private void OnShootChecked()
		{
			GameObject projectile = _bulletPool.GetObject();

			// Shoot the projectile if it exists
			if (projectile)
				_shootProjectileModule.Shoot(projectile, _equippedGun.shootForce, _equippedGun.spray);
		}

		public bool IsShooting()
		{
			return _isShooting;
		}

		public void StopShoot()
		{
			if (_shootController)
			{
				_shootController.StopChecking();
				_isShooting = false;
			}
		}
	}
}