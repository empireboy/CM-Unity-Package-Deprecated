using UnityEngine;

namespace CM.Orientation
{
	public class AimAnimations : MonoBehaviour
	{
		[SerializeField] private Aim _aim;
		[SerializeField] private Animator _animator;

		[Header("Animation Parameters")]
		[SerializeField] private string _isAimingParam = "IsAiming";

		private void Update()
		{
			_animator.SetBool(_isAimingParam, _aim.IsAiming);
		}
	}
}