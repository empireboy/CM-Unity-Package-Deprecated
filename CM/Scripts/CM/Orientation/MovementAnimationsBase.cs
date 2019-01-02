using UnityEngine;

namespace CM.Orientation
{
	[RequireComponent(typeof(Animator))]
	public class MovementAnimationsBase : MonoBehaviour
	{
		[SerializeField] protected MovementBase movement;

		[Header("Animation Parameters")]
		[SerializeField] protected string isMovingParam = "IsMoving";
		[SerializeField] protected string walkSpeedMultiplierParam = "WalkSpeedMultiplier";

		protected Animator animator;

		private void Awake()
		{
			animator = GetComponent<Animator>();
		}

		public void SetWalkSpeedMultiplier(float multiplier)
		{
			animator.SetFloat(walkSpeedMultiplierParam, multiplier);
		}

		public void ResetWalkSpeedMultiplier()
		{
			animator.SetFloat(walkSpeedMultiplierParam, 1);
		}
	}
}