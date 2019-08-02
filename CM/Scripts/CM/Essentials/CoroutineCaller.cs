using System;
using System.Collections;
using UnityEngine;

namespace CM
{
	public class CoroutineCaller : MonoBehaviour
	{
		private Action _coroutineCaller;

		private static CoroutineCaller _instance;

		public static void AddCoroutineCallback(Action method, float time)
		{
			CreateCoroutineCaller();

			_instance.StartCoroutine(time);

			_instance._coroutineCaller += method;
		}

		private static void CreateCoroutineCaller()
		{
			if (!_instance)
				_instance = new GameObject("[Coroutine Caller]").AddComponent<CoroutineCaller>();
		}

		public void StartCoroutine(float time)
		{
			StartCoroutine(Routine(time));
		}

		private IEnumerator Routine(float time)
		{
			yield return new WaitForSeconds(time);
			_coroutineCaller?.Invoke();
		}
	}
}