using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CM.Lighting
{
	public class FlickeringLight : MonoBehaviour
	{
		public float minWaitTimeOff = 0.5f;
		public float maxWaitTimeOff = 1f;
		public float minWaitTimeOn = 0.5f;
		public float maxWaitTimeOn = 1f;

		private Light _light;

		private void Awake()
		{
			_light = GetComponent<Light>();
		}

		private void Start()
		{
			StartCoroutine(Flickering());
		}

		private IEnumerator Flickering()
		{
			while (true)
			{
				if (_light.enabled)
				{
					yield return new WaitForSeconds(Random.Range(minWaitTimeOff, maxWaitTimeOff));
				}
				else
				{
					yield return new WaitForSeconds(Random.Range(minWaitTimeOn, maxWaitTimeOn));
				}
				_light.enabled = !_light.enabled;
			}
		}
	}
}