using UnityEngine;

namespace CM.Shooting
{
	[System.Serializable]
	[CreateAssetMenu(menuName = "CM/Shooting/ShootingType", order = 1)]
	public class ShootingType : ScriptableObject
	{
		[Tooltip("The number of shots per second.")]
		public float fireRate = 0.5f;

		[Tooltip("The force to apply to the projectile's Rigidbody.")]
		public float shootForce = 1f;

		[Tooltip("The forward angle in degrees of the fired projectile.")]
		public float spray = 0f;

		[Tooltip("The quantity of projectiles per shot.")]
		public float projectilesPerShot = 1f;

		[Header("Burst Fire")]

		[Tooltip("A pre-set number of shots will be fired automaticly if this is set to true.")]
		public bool burstFire = false;

		[Tooltip("The quantity of shots per burst.")]
		public float shotsPerBurst = 3f;

		[Tooltip("Time in seconds between every burst.")]
		public float timeBetweenBurst = 1f;

		[Header("Exponantially Increase Fire Rate")]

		[Tooltip("Exponentially increase the fire rate every shot with this amount.")]
		public float exponentiallyIncreaseFireRateValue = 1f;

		public float exponentiallyIncreaseFireRateMinMax = 1f;
	}
}