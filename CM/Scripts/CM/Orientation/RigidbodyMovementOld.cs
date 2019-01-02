using UnityEngine;
using UnityEngine.Events;

namespace CM.Movement
{
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyMovementOld : MonoBehaviour
	{
		public float speed = 5f;

		[SerializeField] private string _horizontalAxis = "Horizontal";
		[SerializeField] private string _verticalAxis = "Vertical";

		private Vector3 _inputs = Vector3.zero;
		private float _previousInputMagnitude = 0;
		protected bool isMoving = false;
		public bool IsMoving
		{
			get
			{
				return isMoving;
			}
		}

		[SerializeField] private UnityEvent _onMoveStart;
		[SerializeField] private UnityEvent _onMoveStop;

		private Rigidbody _rigidbody;
		private Animator _animator;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_animator = GetComponent<Animator>();
		}

		private void Update()
		{
			_inputs = Vector3.zero;
			_inputs.x = Input.GetAxis(_horizontalAxis);
			_inputs.z = Input.GetAxis(_verticalAxis);

			bool biggerMagnitude = (_inputs.magnitude > _previousInputMagnitude && !Mathf.Approximately(_inputs.magnitude, _previousInputMagnitude) || _inputs.magnitude >= 1);
			bool smallerMagnitude = (_inputs.magnitude < _previousInputMagnitude && !Mathf.Approximately(_inputs.magnitude, _previousInputMagnitude) || _inputs.magnitude <= 0);

			if (biggerMagnitude && !IsMoving)
				_onMoveStart.Invoke();

			if (smallerMagnitude && IsMoving)
				_onMoveStop.Invoke();

			isMoving = (_inputs.magnitude > _previousInputMagnitude || _inputs.magnitude >= 1) ? true : false;

			if (_animator)
				_animator.SetBool("IsMoving", IsMoving);

			_inputs = transform.TransformDirection(_inputs);

			_previousInputMagnitude = _inputs.magnitude;
		}

		private void FixedUpdate()
		{
			_rigidbody.MovePosition(_rigidbody.position + _inputs * speed * Time.fixedDeltaTime);
		}
	}
}