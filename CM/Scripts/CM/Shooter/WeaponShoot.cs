using UnityEngine;

namespace CM.Shooter
{
	public class WeaponShoot : MonoBehaviour
	{
		[SerializeField] private float _shootRate = 0.5f;
		[SerializeField] private Ammo _ammo;

		public delegate void ShootHandler();
		public event ShootHandler OnShoot;
		public delegate void ShootStartHandler();
		public event ShootStartHandler OnShootStart;
		public delegate void ShootStopHandler();
		public event ShootStopHandler OnShootStop;

		private bool _isShooting = false;
		public bool IsShooting
		{
			get
			{
				return _isShooting;
			}
		}

		private float _shootTimer = 0;
		private float _currentAmmo;

		private WeaponReload _weaponReload;

		private void Awake()
		{
			_weaponReload = GetComponent<WeaponReload>();
		}

		private void Update()
		{
			if (_shootTimer < _shootRate)
				_shootTimer += Time.deltaTime;
		}

		public void Shoot()
		{
			if (_shootTimer < _shootRate) return;

			if (!(_ammo.CurrentClipSize > 0 && !_weaponReload.IsReloading)) return;

			_isShooting = true;

			if (OnShoot != null)
				OnShoot();

			if (OnShootStart != null)
				OnShootStart();

			_ammo.ReduceClipSize();

			_shootTimer = 0;
		}

		public void ShootStop()
		{
			_isShooting = false;

			if (OnShootStop != null)
				OnShootStop();
		}
	}
}