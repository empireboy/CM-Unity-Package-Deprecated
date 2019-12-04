using CM.Essentials;

namespace CM.Shooting
{
	public class GunObject : Entity, IGunTrigger, IShoot
	{
		private IGunTrigger[] _gunTriggerModules;
		private IShoot[] _shootModules;

		protected override void OnAwake()
		{
			base.OnAwake();

			_gunTriggerModules = GetModules<IGunTrigger>(true);
			_shootModules = GetModules<IShoot>(true);
		}

		public void SetTriggerState(GunTriggerState state)
		{
			foreach (IGunTrigger module in _gunTriggerModules)
			{
				module.SetTriggerState(state);
			}
		}

		public void Trigger()
		{
			foreach (IGunTrigger module in _gunTriggerModules)
			{
				module.Trigger();
			}
		}

		public void Shoot()
		{
			CM_Debug.Log("CM.Shooting", "You can't call the Shoot method directly, use " + this + ".Trigger() instead");
		}

		public bool IsShooting()
		{
			return (_shootModules.Length > 0) ? _shootModules[0].IsShooting() : false;
		}
	}
}
