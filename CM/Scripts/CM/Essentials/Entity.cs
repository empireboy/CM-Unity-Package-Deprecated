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
		//private string _moduleSuffix = "_Module";

		private void Awake()
		{
			OnAwake();
		}

		private void Start()
		{
			OnStart();
		}

		protected virtual void OnAwake()
		{
			if (!CM_Debug.CategoryExists("CM Entity"))
				CM_Debug.AddCategory("CM Entity", false);

			// Create Module Parent
			if (!GetModuleObject())
			{
				GameObject moduleParent = new GameObject();
				moduleParent.transform.parent = transform;
				moduleParent.name = _moduleParentName;
			}

			// Get Modules, check if the module parent exists
			if (GetModuleObject())
				InitializeModules();
		}

		protected virtual void OnStart()
		{
			// This can be overridden
		}

		public void InitializeModules()
		{
			CM_Debug.Log("CM Entity", "Initializing Modules");
			_moduleInterfaces = this.GetType().GetInterfaces();
		}

		public GameObject GetModuleObject()
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
			CM_Debug.Log("CM Entity", "Getting Modules of " + typeof(T).ToString());

			GameObject moduleObject = GetModuleObject();

			T[] modules = null;
			if (moduleObject)
			{
				modules = moduleObject.GetComponents<T>();
			}

			return modules;
		}

		public Component[] GetModules(Type moduleInterface)
		{
			CM_Debug.Log("CM Entity", "Getting Modules of " + moduleInterface.ToString());

			GameObject moduleObject = GetModuleObject();

			Component[] modules = null;
			if (moduleObject)
			{
				modules = moduleObject.GetComponents(moduleInterface);
			}

			return modules;
		}
	}
}