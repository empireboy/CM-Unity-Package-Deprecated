using UnityEngine;

namespace CM.Orientation
{
	[RequireComponent(typeof(Animator))]
	public class JumpAnimations : MonoBehaviour
	{
		[SerializeField] private GroundCheckerBase _groundChecker;

		private Animator _animator;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}

		private void Update()
		{
			if (_animator)
				_animator.SetBool("IsGrounded", _groundChecker.IsGrounded);
		}
	}
}