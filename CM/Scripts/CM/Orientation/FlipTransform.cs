using UnityEngine;

namespace CM.Orientation
{
	public class FlipTransform : MonoBehaviour, IFlip
	{
		[SerializeField]
		protected Transform flipTransform;

		private bool _isFlipped = false;
		private bool _isFlipping = false;

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
			if (!gameObject.activeInHierarchy)
				return;

			_isFlipped = flip;

			if (!_isFlipping)
			{
				_isFlipping = true;
				OnFlip(flip);
			}
		}

		protected virtual void OnFlip(bool flip)
		{
			Quaternion targetRotation = (flip) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);

			flipTransform.localRotation = targetRotation;
		}

		protected virtual void OnFlipFinish()
		{
			_isFlipping = false;
		}

		public bool IsFlipped()
		{
			return _isFlipped;
		}

		public bool IsFlipping()
		{
			return _isFlipping;
		}
	}
}