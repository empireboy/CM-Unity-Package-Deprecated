namespace CM.Shooting
{
	public interface IGunTrigger
	{
		void SetTriggerState(GunTriggerState state);
		void Trigger();
	}
}