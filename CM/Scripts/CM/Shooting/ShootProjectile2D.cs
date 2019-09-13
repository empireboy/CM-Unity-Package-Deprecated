using UnityEngine;

namespace CM.Shooting
{
	public class ShootProjectile2D : MonoBehaviour, IShootProjectile
	{
		[SerializeField]
		private Transform _shootTransform;

		public void Shoot(GameObject projectile, float force, float spray)
		{
			projectile.transform.position = _shootTransform.position;
			projectile.transform.rotation = _shootTransform.rotation;

			// Spray
			if (spray > 0)
			{
				projectile.transform.rotation = Quaternion.Euler(new Vector3(projectile.transform.eulerAngles.x, projectile.transform.eulerAngles.y, projectile.transform.eulerAngles.z + Random.Range(-spray, spray)));
			}

			Rigidbody2D projectileRigidbody2D = projectile.GetComponent<Rigidbody2D>();

			if (projectileRigidbody2D)
			{
				projectileRigidbody2D.AddForce(projectile.transform.right * force);
			}
		}
	}
}
