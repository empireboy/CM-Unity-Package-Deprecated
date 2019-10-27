using UnityEngine;

namespace CM.Shooting
{
	public interface IShootProjectile
	{
		void Shoot(float force, float spray, float damage);
		void Shoot(GameObject projectile, float force, float spray);
	}
}