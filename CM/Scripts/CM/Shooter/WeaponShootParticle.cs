using UnityEngine;

namespace CM.Shooter
{
	public class WeaponShootParticle : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _muzzleFlash;

		private void Awake()
		{
			if (!_muzzleFlash)
				enabled = false;
		}

		private void Start()
		{
			transform.root.GetComponentInChildren<WeaponShoot>().OnShoot += OnShoot;
		}

		private void OnShoot()
		{
			_muzzleFlash.Play();
		}
	}
}