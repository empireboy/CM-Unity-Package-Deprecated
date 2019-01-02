namespace CM.Orientation
{
	public class MovementAnimations : MovementAnimationsBase
	{
		private void Update()
		{
			animator.SetBool(isMovingParam, movement.IsMoving);
		}
	}
}