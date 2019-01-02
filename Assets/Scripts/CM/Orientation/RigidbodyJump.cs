using UnityEngine;
using UnityEngine.Events;

namespace CM.Orientation
{
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyJump : MonoBehaviour
	{
		public float jumpHeight = 5f;

		[SerializeField] private GroundCheckerBase _groundChecker;

		[SerializeField] private UnityEvent _onJumpStart;
		[SerializeField] private UnityEvent _onJumpStop;

		private Rigidbody _rigidbody;
		private Animator _animator;
		private PreviousValue<bool> p_isJumping;
		public bool IsJumping
		{
			get
			{
				return p_isJumping.value;
			}
		}

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_animator = GetComponent<Animator>();
			p_isJumping = new PreviousValue<bool>();
		}

		private void Update()
		{
			p_isJumping.value = (!_groundChecker.IsGrounded) ? true : false;

			if (p_isJumping.Previous && _groundChecker.IsGrounded)
				_onJumpStop.Invoke();
		}

		public void Jump()
		{
			if (_groundChecker.IsGrounded && !_animator.GetCurrentAnimatorStateInfo(0).IsName("GroundHit") && !_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
			{
				_rigidbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
				_onJumpStart.Invoke();
			}
		}
	}
}