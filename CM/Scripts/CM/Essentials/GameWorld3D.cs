using UnityEngine;
using NaughtyAttributes;

namespace CM.Essentials
{
	public class GameWorld3D : MonoBehaviour
	{
		[OnValueChanged("SetGlobalGravity")]
		public Vector3 globalGravity = Physics.gravity;

		private void Awake()
		{
			Physics.gravity = globalGravity;
		}

		private void SetGlobalGravity()
		{
			Physics.gravity = globalGravity;
		}
	}
}