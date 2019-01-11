using UnityEngine;

namespace CM.Essentials.FSM
{
	public class MoveToAction : StateAction
	{
		public float speed = 1;
		public string targetTag = "Enemy";

		private Transform _closestTarget;

		public override void Enter()
		{
			_closestTarget = transform.root.gameObject.FindClosestGameObjectWithTag(targetTag).transform;
		}

		public override void ActionUpdate()
		{
			transform.root.position = Vector3.MoveTowards(transform.root.position, _closestTarget.position, speed * Time.deltaTime);
		}
	}
}