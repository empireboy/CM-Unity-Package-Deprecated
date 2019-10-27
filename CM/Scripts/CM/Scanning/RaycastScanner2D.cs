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
		private Transform _scannerTransform;

		public GameObject GetTarget()
		{
			RaycastHit2D hit = Physics2D.Linecast(_scannerTransform.position, _scannerTransform.position + _scannerTransform.right * _range, _targetMask);

			return hit.transform.gameObject;
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(_scannerTransform.position, _scannerTransform.position + _scannerTransform.right * _range);
		}
	}
}
