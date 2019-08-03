using UnityEngine;

namespace CM.Orientation
{
	public class RigidbodyMovement : MonoBehaviour, IMovement2D
	{
		public float moveSpeed = 2f;

		[SerializeField]
		private Rigidbody _rigidbody;

		public void Initialize(Rigidbody rigidbody)
		{
			_rigidbody = rigidbody;
		}

		public void Move(Vector2 input)
		{
			_rigidbody.velocity = new Vector3(input.x * moveSpeed, _rigidbody.velocity.y, input.y * moveSpeed);
		}
	}
}