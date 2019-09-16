namespace CM.Shooting
{
	public interface IGunTrigger
	{
		void SetState(GunTriggerState state);
		void Trigger();
	}
}