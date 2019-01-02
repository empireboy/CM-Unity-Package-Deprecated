using UnityEngine;

namespace CM.Shooter
{
	public class WeaponInput : MonoBehaviour
	{
		public string shootKey = "Shoot";
		public string reloadKey = "Reload";

		private void Update()
		{
			if (Input.GetButton(shootKey))
				SendMessage("Shoot", SendMessageOptions.DontRequireReceiver);

			if (Input.GetButtonUp(shootKey))
				SendMessage("ShootStop", SendMessageOptions.DontRequireReceiver);

			if (Input.GetButtonUp(shootKey))
				SendMessage("OnResetTransformLockRandomizer", SendMessageOptions.DontRequireReceiver);

			if (Input.GetButtonDown(reloadKey))
				SendMessage("StartReloading", SendMessageOptions.DontRequireReceiver);
		}
	}
}