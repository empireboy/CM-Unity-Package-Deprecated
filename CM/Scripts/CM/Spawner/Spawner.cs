using UnityEngine;

namespace CM.Spawner
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField]
		protected GameObject objectToSpawn;

		public void Spawn()
		{
			OnSpawn(Instantiate(objectToSpawn));
		}

		protected virtual void OnSpawn(GameObject instantiatedObject)
		{
			instantiatedObject.transform.position = transform.position;
		}
	}
}