using UnityEngine;

namespace CM.Scanner
{
	public class RaycastScanner2D : MonoBehaviour, ITargetScanner
	{
		[SerializeField]
		private float _range = 3f;

		[SerializeField]
		private LayerMask _targetMask;
		public LayerMask TargetMask
		{
			get
			{
				return _targetMask;
			}
		}

		[SerializeField]
		private LayerMask _blockVisionMask;

		[SerializeField]
		private Transform _scannerTransform;

		public GameObject GetTarget()
		{
			RaycastHit2D hit = Physics2D.Raycast(_scannerTransform.position, _scannerTransform.right, _range, _targetMask);

			if (!hit)
				return null;

			RaycastHit2D wallHit = Physics2D.Raycast(_scannerTransform.position, _scannerTransform.right, _range, _blockVisionMask);

			if (hit.distance >= wallHit.distance)
				return null;

			return hit.transform.gameObject;
		}

		public void SetRange(float range)
		{
			_range = range;
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(_scannerTransform.position, _scannerTransform.position + _scannerTransform.right * _range);
		}
	}
}
