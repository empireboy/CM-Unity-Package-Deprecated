using UnityEngine;

namespace CM.Shooter
{
	public class WeaponShootAudio : MonoBehaviour
	{
		public AudioSource shootSound;

		private void Awake()
		{
			if (!shootSound)
				enabled = false;
		}

		private void Start()
		{
			transform.root.GetComponentInChildren<WeaponShoot>().OnShoot += OnShoot;
		}

		private void OnShoot()
		{
			if (shootSound)
				shootSound.Play();
		}
	}
}