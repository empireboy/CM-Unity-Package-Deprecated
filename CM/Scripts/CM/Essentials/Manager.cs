using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials
{
	public class Manager<T> : MonoBehaviour where T : class
	{
		protected List<T> interfaces = new List<T>();

		private void Start()
		{
			if (!CM_Debug.CategoryExists("CM.Essentials.Manager"))
				CM_Debug.AddCategory("CM.Essentials.Manager", false);
		}

		public void AddInterface(T newInterface)
		{
			interfaces.Add(newInterface);

			CM_Debug.Log("CM.Essentials.Manager", "Added an interface of type " + typeof(T) + " to " + this + ". This Manager now has a total of " + interfaces.Count + " interfaces");
		}
	}
}