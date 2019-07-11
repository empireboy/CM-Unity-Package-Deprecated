using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials
{
	public abstract class Entity : MonoBehaviour
	{
		[Header("Entity")]

		[SerializeField]
		private List<string> _moduleInterfaceNames;

		public void CreateModules()
		{
			GameObject moduleParent = new GameObject();
			moduleParent.transform.parent = transform;
			moduleParent.name = "Modules";

			for (int i = 0; i < _moduleInterfaceNames.Count; i++)
			{
				GameObject moduleObject = new GameObject();
				moduleObject.transform.parent = moduleParent.transform;
				moduleObject.name = _moduleInterfaceNames[i].Remove(0, 1) + "_Module";
			}
		}
	}
}