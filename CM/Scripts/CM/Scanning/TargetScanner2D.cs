using CM.Orientation;
using UnityEngine;

namespace CM.Scanner
{
	public class TargetScanner2D : MonoBehaviour, ITargetScanner
	{
		[SerializeField]
		private float _range = 3f;

		[SerializeField]
		private Distance _targetDistance;

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
			Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_scannerTransform.position, _range, TargetMask);

			if (hitColliders.Length <= 0)
				return null;

			GameObject bestTarget = null;
			float bestRange = 0;

			for (int i = 0; i < hitColliders.Length; i++)
			{
				// Block vision
				if (Physics2D.Linecast(hitColliders[i].transform.position, _scannerTransform.position, _blockVisionMask))
					continue;

				float distance = Vector3.Distance(hitColliders[i].transform.position, _scannerTransform.position);

				if (bestTarget == null)
				{
					bestTarget = hitColliders[i].gameObject;
					bestRange = distance;
				}

				switch (_targetDistance)
				{
					case Distance.Closest:
						if (distance < bestRange)
						{
							bestTarget = hitColliders[i].gameObject;
							bestRange = distance;
						}
						break;
					case Distance.Furthest:
						if (distance > bestRange)
						{
							bestTarget = hitColliders[i].gameObject;
							bestRange = distance;
						}
						break;
				}
			}

			return bestTarget;
		}

		private void OnDrawGizmosSelected()
		{
			if (_scannerTransform && _range > 0f)
			{
				Gizmos.color = Color.green;
				Gizmos.DrawWireSphere(_scannerTransform.position, _range);
			}

			GameObject bestTarget = GetTarget();

			if (bestTarget)
			{
				Gizmos.color = Color.white;
				Gizmos.DrawLine(_scannerTransform.position, bestTarget.transform.position);
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(bestTarget.transform.position, 1f);
			}
		}
	}
}
