using UnityEngine;

namespace CM.Shooting
{
	[CreateAssetMenu(menuName = "CM/Shooting/ShootingType", order = 1)]
	public class ShootingType : ScriptableObject
	{
		public AnimationCurve fireRate = new AnimationCurve();
	}
}