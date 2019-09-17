using UnityEngine;
using UnityEngine.Events;

namespace CM.Essentials
{
	public class Health : MonoBehaviour, IDamageable, IHealable
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

		private enum DeathType { Destroy, Disable, Nothing }

		[SerializeField]
		private DeathType _onDeath = DeathType.Nothing;

		public delegate void TakeDamageHandler(float value);
		public event TakeDamageHandler TakeDamageEvent;

		public delegate void DeathHandler(float value);
		public event DeathHandler DeathEvent;

		public delegate void FullHealthHandler(float value);
		public event FullHealthHandler FullHealthEvent;

		public UnityEvent deathEvent;

		private void Start()
		{
			_currentHealth = _health;
		}

		private void OnEnable()
		{
			_currentHealth = _health;
		}

		public void TakeDamage(float damage)
		{
			_currentHealth -= damage;

			// Health is empty
			if (_currentHealth <= 0)
			{
				DeathEvent?.Invoke(Mathf.Abs(_currentHealth));
				deathEvent.Invoke();
			}

			_currentHealth = Mathf.Clamp(_currentHealth, 0f, _health);

			TakeDamageEvent?.Invoke(damage);

			if (_currentHealth <= 0)
			{
				switch (_onDeath)
				{
					case DeathType.Disable:
						_rootObject.SetActive(false);
						break;
					case DeathType.Destroy:
						Destroy(_rootObject);
						break;
				}
			}
		}

		public void Heal(float health)
		{
			_currentHealth += health;

			// Health reached its maximum
			if (_currentHealth >= _health)
			{
				FullHealthEvent(_currentHealth - _health);
			}

			_currentHealth = Mathf.Clamp(_currentHealth, 0f, _health);
		}
	}
}