using UnityEngine;

namespace CM.Orientation
{
	public class RotateToPosition : MonoBehaviour, IRotateTo
	{
		[SerializeField]
		protected float rotationSpeed = 1f;

		[SerializeField]
		protected Transform lookingTransform;

		private void Awake()
		{
			OnAwake();
		}

		private void Start()
		{
			OnStart();
		}

		protected virtual void OnAwake()
		{
			// Can be overridden
		}

		protected virtual void OnStart()
		{
			// Can be overridden
		}

		public void RotateTo(Vector3 position)
		{
			LookAt(position);
		}

		protected virtual void LookAt(Vector3 position)
		{
			Vector3 targetDirection = position - lookingTransform.position;
			float step = rotationSpeed * Time.deltaTime;
			Vector3 newDirection = Vector3.RotateTowards(lookingTransform.forward, targetDirection, step, 0.0f);

			lookingTransform.rotation = Quaternion.LookRotation(newDirection);
		}

		public Vector3 GetPosition()
		{
			return lookingTransform.position;
		}
	}
}