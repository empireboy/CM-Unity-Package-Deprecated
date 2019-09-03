using UnityEngine;

namespace CM.Orientation
{
	public class LookAtPosition : MonoBehaviour, IRotateTo
	{
		[SerializeField]
		Transform _lookingTransform;

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
			_lookingTransform.LookAt(position);
		}

		public Vector3 GetPosition()
		{
			return _lookingTransform.position;
		}
	}
}