using UnityEngine;

namespace CM.Shooting
{
	public class GunEquipper : MonoBehaviour, IEquipGun
	{
		[SerializeField]
		private GameObject _gunEquipModule;

		public void EquipGun(Gun gun)
		{
			_gunEquipModule.GetComponent<IEquipGun>().EquipGun(gun);
		}
	}
}