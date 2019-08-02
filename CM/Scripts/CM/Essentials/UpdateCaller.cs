using System;
using UnityEngine;

namespace CM
{
	public class UpdateCaller : MonoBehaviour
	{
		private Action _updateCallback;
		private Action _lateUpdateCallback;
		private Action _fixedUpdateCallback;

		private static UpdateCaller _instance;

		public static void AddUpdateCallback(Action updateMethod)
		{
			CreateUpdateCaller();

			_instance._updateCallback += updateMethod;
		}

		public static void AddLateUpdateCallback(Action lateUpdateMethod)
		{
			CreateUpdateCaller();

			_instance._lateUpdateCallback += lateUpdateMethod;
		}

		public static void AddFixedUpdateCallback(Action fixedUpdateMethod)
		{
			CreateUpdateCaller();

			_instance._fixedUpdateCallback += fixedUpdateMethod;
		}

		private static void CreateUpdateCaller()
		{
			if (!_instance)
				_instance = new GameObject("[Update Caller]").AddComponent<UpdateCaller>();
		}

		private void Update()
		{
			if (_updateCallback != null)
				_updateCallback();
		}

		private void LateUpdate()
		{
			if (_lateUpdateCallback != null)
				_lateUpdateCallback();
		}

		private void FixedUpdate()
		{
			if (_fixedUpdateCallback != null)
				_fixedUpdateCallback();
		}
	}
}