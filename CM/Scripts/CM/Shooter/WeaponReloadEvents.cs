using UnityEngine;
using UnityEngine.Events;

namespace CM.Shooter
{
	public class WeaponReloadEvents : MonoBehaviour
	{
		[SerializeField] private UnityEvent _onReloadStart;
		[SerializeField] private UnityEvent _onReloadFinish;

		private void Start()
		{
			transform.root.GetComponentInChildren<WeaponReload>().OnReloadStart += OnReloadStart;
			transform.root.GetComponentInChildren<WeaponReload>().OnReloadFinish += OnReloadFinished;
		}

		private void OnReloadStart()
		{
			_onReloadStart.Invoke();
		}

		public void OnReloadFinished()
		{
			_onReloadFinish.Invoke();
		}
	}
}