using UnityEngine;

namespace CM.Shooting
{
	public class ShootProjectile2D : MonoBehaviour, IShootProjectile
	{
		[SerializeField]
		private Transform _shootTransform;

		public void Shoot(GameObject projectile, float force)
		{
			projectile.transform.position = _shootTransform.position;
			projectile.transform.rotation = _shootTransform.rotation;

			Rigidbody2D projectileRigidbody2D = projectile.GetComponent<Rigidbody2D>();

			if (projectileRigidbody2D)
			{
				projectileRigidbody2D.AddForce(projectile.transform.right * force);
			}
		}
	}
}
