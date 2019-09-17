namespace CM.Essentials
{
	public class ChainHealthDamage : ChainHealth
	{
		private void Start()
		{
			healthCaller.DeathEvent += OnChain;
		}

		protected override void OnChain(float value)
		{
			healthReceiver.TakeDamage(value);
		}
	}
}