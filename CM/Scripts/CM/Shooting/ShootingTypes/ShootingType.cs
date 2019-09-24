using UnityEngine;

namespace CM.Shooting
{
	[CreateAssetMenu(menuName = "CM/Shooting/ShootingType", order = 1)]
	public class ShootingType : ScriptableObject
	{
		public float fireRate = 0.5f;
		public float shootForce = 1f;
		public float spray = 0f;
		public float projectilesPerShot = 1f;
		public GameObject projectilePrefab;
	}
}