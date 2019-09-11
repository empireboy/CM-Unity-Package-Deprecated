using UnityEngine;

namespace CM.Shooting
{
	public class ShootProjectile3D : MonoBehaviour, IShootProjectile
	{
		[SerializeField]
		private Transform _shootTransform;

		[SerializeField]
		private ObjectPool _projectilePool;

		[SerializeField]
		private float _shootTime = 0.25f;

		private float _shootTimer;

		private void Start()
		{
			_shootTimer = _shootTime;
		}

		public void Shoot(GameObject projectile, float force, float spray)
		{
			if (_shootTimer > 0f)
			{
				_shootTimer -= Time.deltaTime;
				return;
			}

			_shootTimer = _shootTime;

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
