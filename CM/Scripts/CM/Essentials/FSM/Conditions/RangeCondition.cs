using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials.FSM
{
	public class RangeCondition : StateCondition
	{
		public float range = 3f;
		public string targetTag = "Enemy";

		private List<Transform> _targets = new List<Transform>();

		public override void Enter()
		{
			GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
			foreach (GameObject targetObject in targetObjects)
				_targets.Add(targetObject.transform);
		}

		public override bool Condition()
		{
			foreach (Transform target in _targets)
			{
				if (Vector3.Distance(transform.root.position, target.position) < range)
				{
					ChangeState();
					return false;
				}
			}
			return true;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.root.position, range);
		}
	}
}