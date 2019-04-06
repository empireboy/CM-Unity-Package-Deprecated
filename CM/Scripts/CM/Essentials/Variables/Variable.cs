using System;
using UnityEngine;

namespace CM.Essentials.Variables
{
	public class Variable<T> : ScriptableObject, ISerializationCallbackReceiver
	{
		public T initialValue;

		[NonSerialized]
		public T value;

		public void OnAfterDeserialize()
		{
			value = initialValue;
		}

		public void OnBeforeSerialize()
		{

		}
	}
}