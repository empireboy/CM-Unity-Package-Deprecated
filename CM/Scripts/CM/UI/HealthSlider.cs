using UnityEngine;
using UnityEngine.UI;

namespace CM.UI
{
	[RequireComponent(typeof(Slider))]
	public class HealthSlider : MonoBehaviour
	{
		[SerializeField]
		private Essentials.Health _health;

		private Slider _slider;

		private void Awake()
		{
			_slider = GetComponent<Slider>();
		}

		private void Start()
		{
			_health.TakeDamageEvent += OnTakeDamage;
			_health.FullHealthEvent += OnFullHealth;
		}

		private void OnTakeDamage(float damage)
		{
			_slider.value -= damage / _health.MaxHealth;
		}

		private void OnFullHealth(float value)
		{
			_slider.value = 1;
		}
	}
}