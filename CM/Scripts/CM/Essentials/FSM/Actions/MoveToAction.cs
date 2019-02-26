using NaughtyAttributes;
using UnityEngine;

namespace CM.Essentials.FSM
{
	public class MoveToAction : StateAction
	{
		[Header("Types")]

		[Dropdown("_targetTypes")]
		public string targetType;

		[ShowIf("ShowRangeTypes")]
		[Dropdown("_rangeTypes")]
		public string rangeType;

		private string[] _targetTypes = new string[] { "Tag", "Layer", "Transform" };
		private string[] _rangeTypes = new string[] { "Closest", "Furthest" };

		[ShowIf("TypeIsTag")]
		public string targetTag;

		[ShowIf("TypeIsLayer")]
		public LayerMask targetLayer;

		[ShowIf("TypeIsTransform")]
		public Transform targetTransform;

		[Header("Properties")]

		public float speed = 1;

		private Transform _target;

		public override void Enter()
		{
			// Get closest or furthest target if type is tag or layer
			if (ShowRangeTypes())
			{
				switch (targetType)
				{
					case "Tag":
						switch (rangeType)
						{
							case "Closest":
								_target = transform.root.gameObject.FindClosestGameObjectWithTag(targetTag).transform;
								break;
							case "Furthest":
								_target = transform.root.gameObject.FindFurthestGameObjectWithTag(targetTag).transform;
								break;
						}
						break;
					/*case "Layer":
						switch (rangeType)
						{
							case "Closest":
								_target = transform.root.gameObject.FindClosestGameObjectWithLayerMask(targetLayer).transform;
								break;
							case "Furthest":
								_target = transform.root.gameObject.FindFurthestGameObjectWithLayerMask(targetLayer).transform;
								break;
						}
						break;*/
				}
			}

			if (TypeIsTransform())
			{
				_target = targetTransform;
			}
		}

		public override void ActionUpdate()
		{
			if (_target != null)
				transform.root.position = Vector3.MoveTowards(transform.root.position, _target.position, speed * Time.deltaTime);
		}

		private bool ShowRangeTypes()
		{
			if (
				targetType == "Tag" ||
				targetType == "Layer"
			) 
			{
				return true;
			}
			return false;
		}

		private bool TypeIsTag()
		{
			if (targetType == "Tag")
				return true;

			return false;
		}

		private bool TypeIsLayer()
		{
			if (targetType == "Layer")
				return true;

			return false;
		}

		private bool TypeIsTransform()
		{
			if (targetType == "Transform")
				return true;

			return false;
		}
	}
}