using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials
{
	public class Manager<T> : MonoBehaviour where T : class
	{
		protected List<T> interfaces = new List<T>();

		public void AddInterface(T newInterface)
		{
			interfaces.Add(newInterface);
		}
	}
}