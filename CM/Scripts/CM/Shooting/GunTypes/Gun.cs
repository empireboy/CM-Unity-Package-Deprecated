using UnityEngine;

namespace CM.Shooting
{
	[CreateAssetMenu(menuName = "CM/Shooting/GunType", order = 0)]
	public class Gun : ScriptableObject
	{
		public ShootingType shootingType;
		public GameObject projectile;
		public float shootForce = 1f;
		public float spray = 0f;
		public float projectilesPerShot = 1f;
	}
}