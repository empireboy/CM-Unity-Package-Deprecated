using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials
{
	public class Manager<T> : MonoBehaviour where T : class
	{
		protected List<T> interfaces = new List<T>();

		private void Awake()
		{
			OnAwake();
		}

		protected virtual void OnAwake()
		{
			if (!CM_Debug.CategoryExists("CM", "CM.Essentials.Manager"))
				CM_Debug.AddCategory(false, "CM", "CM.Essentials.Manager");
		}

		public void AddInterface(T newInterface)
		{
			interfaces.Add(newInterface);

			CM_Debug.Log("CM", "CM.Essentials.Manager", "Added an interface of type " + typeof(T) + " to " + this + ". This Manager now has a total of " + interfaces.Count + " interfaces");
		}
	}
}