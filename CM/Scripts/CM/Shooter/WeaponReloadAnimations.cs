using UnityEngine;

namespace CM.Shooter
{
	public class WeaponReloadAnimations : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		[Header("Animation Parameters")]
		[SerializeField] private string _reloadingState = "Reload";
		[SerializeField] private string _isReloadingParam = "IsReloading";

		private PreviousValue<AnimatorStateInfo> p_animatorStateInfo;

		private void Awake()
		{
			p_animatorStateInfo = new PreviousValue<AnimatorStateInfo>();
		}

		private void Start()
		{
			WeaponReload weaponReload = GetComponent<WeaponReload>();
			weaponReload.OnReloadStart += OnReloadStart;
			weaponReload.OnReloadFinish += OnReloadFinish;
		}

		private void Update()
		{
			p_animatorStateInfo.value = _animator.GetCurrentAnimatorStateInfo(0);

			if (!p_animatorStateInfo.value.IsName(_reloadingState) && p_animatorStateInfo.Previous.IsName(_reloadingState))
				GetComponent<WeaponReload>().FinishReloading();
		}

		private void OnReloadStart()
		{
			_animator.SetBool(_isReloadingParam, true);
		}

		private void OnReloadFinish()
		{
			_animator.SetBool(_isReloadingParam, false);
		}
	}
}