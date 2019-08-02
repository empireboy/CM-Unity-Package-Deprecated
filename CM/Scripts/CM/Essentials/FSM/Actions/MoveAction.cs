using NaughtyAttributes;
using UnityEngine;

namespace CM.Essentials.FSM
{
	public class MoveAction : StateAction
	{
		public float speed = 1;
		public bool randomDirection = false;

		[HideIf("randomDirection")]
		[Dropdown("_directions")]
		public Vector3 direction = Vector3.zero;

		private DropdownList<Vector3> _directions = new DropdownList<Vector3>()
		{
			{ "Right", Vector3.right },
			{ "Left", Vector3.left },
			{ "Up", Vector3.up },
			{ "Down", Vector3.down }
		};

		public override void Enter()
		{
			if (randomDirection)
				direction = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
		}

		public override void ActionUpdate()
		{
			transform.root.position = transform.position + (direction * speed * Time.deltaTime);
		}
	}
}