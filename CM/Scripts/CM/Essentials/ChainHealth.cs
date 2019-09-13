using UnityEngine;

namespace CM.Essentials
{
	public class ChainHealth : MonoBehaviour
	{
		[SerializeField]
		private Health _healthCaller;

		[SerializeField]
		private Health _healthReceiver;

		private void Start()
		{
			_healthCaller.DeathEvent += OnBaseDeath;
		}

		private void OnBaseDeath(float damage)
		{
			_healthReceiver.TakeDamage(damage);
		}
	}
}