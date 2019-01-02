using UnityEngine;

namespace CM.Shooter
{
	public class WeaponReload : MonoBehaviour
	{
		[SerializeField] private Ammo _ammo;

		public delegate void ReloadStartHandler();
		public event ReloadStartHandler OnReloadStart;
		public delegate void ReloadFinishHandler();
		public event ReloadFinishHandler OnReloadFinish;

		private bool _isReloading = false;
		public bool IsReloading
		{
			get
			{
				return _isReloading;
			}
		}

		public void StartReloading()
		{
			if (_ammo.CurrentClips > 0 && _ammo.CurrentClipSize < _ammo.ClipSize)
			{
				_isReloading = true;
				if (OnReloadStart != null)
					OnReloadStart();
			}
		}

		public void FinishReloading()
		{
			_isReloading = false;

			_ammo.Reload();

			OnReloadFinish.Invoke();
		}
	}
}