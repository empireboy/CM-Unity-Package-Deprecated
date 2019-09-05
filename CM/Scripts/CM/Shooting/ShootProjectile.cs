using UnityEngine;

namespace CM.Shooting
{
	public class ShootProjectile : MonoBehaviour, IShootProjectile
	{
		[SerializeField]
		private Transform _shootTransform;

		public void Shoot(GameObject projectile)
		{
			GameObject instantiatedProjectile = Instantiate(projectile, null, _shootTransform);
			instantiatedProjectile.transform.rotation = _shootTransform.rotation;
		}
	}
}
