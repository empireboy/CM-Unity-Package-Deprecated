using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials
{
	public class Trigger : MonoBehaviour
	{
		public delegate void TriggerHandler();
		public event TriggerHandler TriggerEvent;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			TriggerEvent?.Invoke();
		}
	}
}
