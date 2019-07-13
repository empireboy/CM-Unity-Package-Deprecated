using System;
using UnityEngine;

namespace CM.Essentials
{
	public abstract class Entity : MonoBehaviour
	{
		[Header("Entity")]

		private Type[] _moduleInterfaceNames;
		public Type[] ModuleInterfaceNames { get => _moduleInterfaceNames; }

		private string _moduleParentName = "Modules";
		private string _moduleSuffix = "_Module";

		public void CreateModules()
		{
			// Destroy Module Parent if exists
			DestroyImmediate(GetParentModuleObject());

			// Create Module Parent
			GameObject moduleParent = new GameObject();
			moduleParent.transform.parent = transform;
			moduleParent.name = _moduleParentName;

			// Get interfaces
			_moduleInterfaceNames = this.GetType().GetInterfaces();

			// Create all Modules
			for (int i = 0; i < _moduleInterfaceNames.Length; i++)
			{
				GameObject moduleObject = new GameObject();
				moduleObject.transform.parent = moduleParent.transform;
				moduleObject.name = _moduleInterfaceNames[i].ToString().Remove(0, 1) + _moduleSuffix;
			}
		}

		public GameObject GetModuleObject<T>()
		{
			GameObject parentModule = GetParentModuleObject();

			Transform[] children = parentModule.GetComponentsInChildren<Transform>();
			foreach (Transform child in children)
			{
				if (child.name == (typeof(T).ToString().Remove(0, 1) + _moduleSuffix))
				{
					return child.gameObject;
				}
			}

			return null;
		}

		private GameObject GetParentModuleObject()
		{
			Transform[] children = gameObject.GetComponentsInChildren<Transform>();
			foreach (Transform child in children)
			{
				if (child.name == _moduleParentName)
				{
					return child.gameObject;
				}
			}

			return null;
		}

		public T[] GetModules<T>()
		{
			GameObject moduleObject = GetModuleObject<T>();
			T[] modules = moduleObject.GetComponents<T>();

			return modules;
		}
	}
}