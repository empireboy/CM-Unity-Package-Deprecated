namespace CM.Essentials
{
	public class ChainHealthHealing : ChainHealth
	{
		private void Start()
		{
			healthCaller.FullHealthEvent += OnChain;
		}

		protected override void OnChain(float value)
		{
			healthReceiver.Heal(value);
		}
	}
}