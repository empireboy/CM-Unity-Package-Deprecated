using UnityEngine;
using UnityEngine.Events;

namespace CM.Essentials
{
	[RequireComponent(typeof(Health))]
	public class HealthEvents : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent _takeDamageEvent;

		private void Start()
		{
			GetComponent<Health>().TakeDamageEvent += OnTakeDamage;
		}

		private void OnTakeDamage(float damage)
		{
			_takeDamageEvent.Invoke();
		}
	}
}