using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials.FSM
{
	public class MoveToAction : StateAction
	{
		public float speed = 1;
		public string targetTag = "Enemy";

		private List<Transform> _targets = new List<Transform>();
		private Transform _closestTarget;

		public override void Enter()
		{
			GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
			foreach (GameObject targetObject in targetObjects)
				_targets.Add(targetObject.transform);

			float closestDistance = -1;
			foreach (Transform target in _targets)
			{
				float distance = Vector3.Distance(target.position, transform.root.position);
				if (distance < closestDistance || closestDistance == -1)
				{
					closestDistance = distance;
					_closestTarget = target;
				}
			}
		}

		public override void ActionUpdate()
		{
			transform.root.position = Vector3.MoveTowards(transform.root.position, _closestTarget.position, speed * Time.deltaTime);
		}
	}
}