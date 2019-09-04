using UnityEngine;

namespace CM.Orientation
{
	public class FlipTransform : MonoBehaviour, IFlip
	{
		[SerializeField]
		protected Transform flipTransform;

		private bool _isFlipped = false;

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

		public void Flip(bool flip)
		{
			_isFlipped = flip;

			OnFlip(flip);
		}

		protected virtual void OnFlip(bool flip)
		{
			Quaternion targetRotation = (flip) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);

			flipTransform.localRotation = targetRotation;
		}

		public bool IsFlipped()
		{
			return _isFlipped;
		}
	}
}