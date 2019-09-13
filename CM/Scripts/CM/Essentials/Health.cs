using UnityEngine;
using UnityEngine.Events;

namespace CM.Essentials
{
	public class Health : MonoBehaviour, IDamageable, IHeal
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

		public delegate void TakeDamageHandler(float damage);
		public event TakeDamageHandler TakeDamageEvent;

		public delegate void DeathHandler(float damage);
		public event DeathHandler DeathEvent;

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

			if (_currentHealth <= 0)
			{
				DeathEvent?.Invoke(Mathf.Abs(_currentHealth));
			}

			_currentHealth = Mathf.Clamp(_currentHealth, 0f, _health);

			TakeDamageEvent?.Invoke(damage);

			deathEvent.Invoke();

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

			_currentHealth = Mathf.Clamp(_currentHealth, 0f, _health);
		}
	}
}