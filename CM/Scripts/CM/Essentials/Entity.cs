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
			string moduleParentName = "Modules";

			// Destroy Module Parent if exists
			Transform[] children = gameObject.GetComponentsInChildren<Transform>();
			foreach (Transform child in children)
			{
				if (child.name == moduleParentName)
				{
					DestroyImmediate(child.gameObject);
					break;
				}
			}

			// Create Module Parent
			GameObject moduleParent = new GameObject();
			moduleParent.transform.parent = transform;
			moduleParent.name = moduleParentName;

			// Create all Modules
			for (int i = 0; i < _moduleInterfaceNames.Count; i++)
			{
				GameObject moduleObject = new GameObject();
				moduleObject.transform.parent = moduleParent.transform;
				moduleObject.name = _moduleInterfaceNames[i].Remove(0, 1) + " _Module";
			}
		}
	}
}