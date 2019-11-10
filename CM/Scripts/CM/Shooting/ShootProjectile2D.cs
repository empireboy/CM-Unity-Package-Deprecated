using UnityEngine;

namespace CM.Shooting
{
	public class ShootProjectile2D : MonoBehaviour, IShootProjectile
	{
		[SerializeField]
		private Transform _shootTransform;

		public void Shoot(GameObject projectile, float force, float spray)
		{
			// Projectile stats
			CM_Debug.Log("CM.Shooting",
				"Shooting a Projectile at " + this + "." +
				" [Projectile: " + projectile + "]" +
				" [Force: " + force + "]" +
				" [Spray: " + spray + "]"
			);

			// Return if shootTransform is null
			if (!_shootTransform)
			{
				CM_Debug.LogWarning("CM.Shooting", this + " has no reference to a Shoot Transform.");
				return;
			}

			projectile.transform.position = _shootTransform.position;
			projectile.transform.rotation = _shootTransform.rotation;

			// Spray
			if (spray > 0)
			{
				projectile.transform.rotation = Quaternion.Euler(new Vector3(projectile.transform.eulerAngles.x, projectile.transform.eulerAngles.y, projectile.transform.eulerAngles.z + Random.Range(-spray, spray)));
			}

			Rigidbody2D projectileRigidbody2D = projectile.GetComponent<Rigidbody2D>();

			// Return if the Projectile has no Rigidbody2D
			if (!projectileRigidbody2D)
			{
				CM_Debug.LogWarning("CM.Shooting", "There is no Rigidbody2D attached to " + projectile + ".");
				return;
			}

			projectileRigidbody2D.AddForce(projectile.transform.right * force);
		}

		public void Shoot(float force, float spray, float damage)
		{
			CM_Debug.Log("CM.Shooting", "Use " + this + ".Shoot(projectile, force, spray) instead of " + this + ".Shoot(force, spray, damage). The " + this + " class requires a (GameObject)projectile.");

			return;
		}
	}
}
