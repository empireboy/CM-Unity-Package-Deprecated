using UnityEngine;

namespace CM.Shooter
{
	public class WeaponShootAnimations : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		[Header("Animation Parameters")]
		[SerializeField] private string _isShootingParam = "IsShooting";

		private void Start()
		{
			WeaponShoot weaponShoot = GetComponent<WeaponShoot>();
			weaponShoot.OnShootStart += OnShootStart;
			weaponShoot.OnShootStop += OnShootStop;
		}

		private void OnShootStart()
		{
			_animator.SetBool(_isShootingParam, true);
		}

		private void OnShootStop()
		{
			_animator.SetBool(_isShootingParam, false);
		}
	}
}