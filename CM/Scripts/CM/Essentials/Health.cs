using UnityEngine;

namespace CM.Essentials
{
	public class Health : MonoBehaviour, IDamageable
	{
		[SerializeField]
		private float _health = 100;

		[SerializeField]
		private GameObject _rootObject;

		public float MaxHealth
		{
			get
			{
				return _health;
			}
		}

		private float _currentHealth;

		public delegate void TakeDamageHandler(float damage);
		public event TakeDamageHandler TakeDamageEvent;

		private void Start()
		{
			_currentHealth = _health;
		}

		public void TakeDamage(float damage)
		{
			_currentHealth -= damage;

			TakeDamageEvent?.Invoke(damage);

			if (_currentHealth <= 0)
				_rootObject.SetActive(false);
		}
	}
}