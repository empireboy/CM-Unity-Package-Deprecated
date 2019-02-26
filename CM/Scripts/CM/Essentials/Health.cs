using UnityEngine;

namespace CM.Essentials
{
	public class Health : MonoBehaviour, IDamageable
	{
		[SerializeField]
		private float _health = 100;

		private float _currentHealth;

		public delegate void TakeDamageHandler();
		public event TakeDamageHandler TakeDamageEvent;

		private void Start()
		{
			_currentHealth = _health;
		}

		public void TakeDamage(int damageValue)
		{
			_currentHealth -= damageValue;

			if (TakeDamageEvent != null)
				TakeDamageEvent();

			if (_currentHealth <= 0)
				Destroy(gameObject);
		}
	}
}