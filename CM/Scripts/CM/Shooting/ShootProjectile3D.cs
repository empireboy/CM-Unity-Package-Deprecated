using UnityEngine;

namespace CM.Shooting
{
	public class ShootProjectile3D : MonoBehaviour, IShootProjectile
	{
		[SerializeField]
		private Transform _shootTransform;

		public void Shoot(GameObject projectile, float force)
		{
			projectile.transform.position = _shootTransform.position;
			projectile.transform.rotation = _shootTransform.rotation;

			Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

			if (projectileRigidbody)
			{
				projectileRigidbody.AddForce(projectile.transform.forward * force);
			}
		}
	}
}
