using UnityEngine;

namespace CM.Shooting
{
	public interface IShootProjectile
	{
		void Shoot(GameObject projectile, float force, float spray, float damage);
	}
}