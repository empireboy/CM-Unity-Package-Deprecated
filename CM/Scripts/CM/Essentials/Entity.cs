using System;
using UnityEngine;

namespace CM.Essentials
{
	[ExecuteInEditMode]
	public abstract class Entity : MonoBehaviour
	{
		[Header("Entity")]

		private Type[] _moduleInterfaces;
		public Type[] ModuleInterfaces { get => _moduleInterfaces; }

		private string _moduleParentName = "Modules";
		private string _moduleSuffix = "_Module";

		private void Awake()
		{
			// Get Modules, check if the module parent exists
			if (GetParentModuleObject())
				InitializeModules();
		}

		public void CreateModules()
		{
			// Destroy Module Parent if exists
			DestroyImmediate(GetParentModuleObject());

			// Create Module Parent
			GameObject moduleParent = new GameObject();
			moduleParent.transform.parent = transform;
			moduleParent.name = _moduleParentName;

			// Get interfaces
			InitializeModules();

			// Create all Modules
			for (int i = 0; i < _moduleInterfaces.Length; i++)
			{
				GameObject moduleObject = new GameObject();
				moduleObject.transform.parent = moduleParent.transform;
				moduleObject.name = _moduleInterfaces[i].ToString().Remove(0, 1) + _moduleSuffix;
			}
		}

		private void InitializeModules()
		{
			_moduleInterfaces = this.GetType().GetInterfaces();
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

		public GameObject GetModuleObject(Type moduleInterface)
		{
			GameObject parentModule = GetParentModuleObject();

			Transform[] children = parentModule.GetComponentsInChildren<Transform>();
			foreach (Transform child in children)
			{
				if (child.name == (moduleInterface.ToString().Remove(0, 1) + _moduleSuffix))
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

		public Component[] GetModules(Type moduleInterface)
		{
			GameObject moduleObject = GetModuleObject(moduleInterface);
			Component[] modules = moduleObject.GetComponents(moduleInterface);

			return modules;
		}
	}
}