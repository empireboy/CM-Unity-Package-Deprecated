using System.Collections;
using UnityEngine;

namespace CM.Spawner
{
	public class SpawnAtCurrentTransform : MonoBehaviour
	{
		public GameObject objectToSpawn;

		public delegate void SpawnHandler(Transform spawningObject);
		public event SpawnHandler SpawnEvent;

		public void Spawn(float angle)
		{
			Spawning();
		}

		public void Spawn(int seconds)
		{
			StartCoroutine(SpawnRoutine(seconds));
		}

		private IEnumerator SpawnRoutine(int seconds)
		{
			yield return new WaitForSeconds(seconds);
			Spawning();
		}

		private void Spawning()
		{
			GameObject spawningObject = Instantiate(objectToSpawn);
			spawningObject.transform.position = transform.position;
			spawningObject.transform.rotation = transform.rotation;

			SpawnEvent?.Invoke(spawningObject.transform);
		}
	}
}