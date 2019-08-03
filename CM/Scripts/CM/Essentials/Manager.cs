using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials
{
	public class Manager<T> : MonoBehaviour where T : class
	{
		public List<T> interfaces;
	}
}