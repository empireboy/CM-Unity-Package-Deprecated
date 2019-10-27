using UnityEngine;

namespace CM.Shooting
{
	public class ShootProjectile3D : MonoBehaviour, IShootProjectile
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
				// TODO: This is the 2D version of spraying. This code needs to be changed for 3D.
				projectile.transform.rotation = Quaternion.Euler(new Vector3(projectile.transform.eulerAngles.x, projectile.transform.eulerAngles.y, projectile.transform.eulerAngles.z + Random.Range(-spray, spray)));
			}

			Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

			if (projectileRigidbody)
			{
				projectileRigidbody.AddForce(projectile.transform.forward * force);
			}
		}

		public void Shoot(float force, float spray, float damage)
		{
			CM_Debug.Log("CM Shooting", "Use " + this + ".Shoot(projectile, force, spray) instead of " + this + ".Shoot(force, spray, damage). The " + this + " class requires a (GameObject)projectile.");

			return;
		}
	}
}
