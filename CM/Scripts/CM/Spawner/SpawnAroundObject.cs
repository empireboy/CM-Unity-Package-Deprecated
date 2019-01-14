using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CM.Spawner
{
	public class SpawnAroundObject : MonoBehaviour
	{
		public Transform target;
		public GameObject objectToSpawn;

		private Vector2 targetPosition;

		private void Start()
		{
			targetPosition = new Vector2(target.position.x, target.position.y);

			Spawn(0, 5);
			Spawn(90, 5);
			Spawn(180, 5);
			Spawn(270, 5);
		}

		public void Spawn(float angle, float radius)
		{
			Spawning(angle, radius);
		}

		public void Spawn(float angle, float radius, int seconds)
		{
			StartCoroutine(SpawnRoutine(angle, radius, seconds));
		}

		private IEnumerator SpawnRoutine(float angle, float radius, int seconds)
		{
			yield return new WaitForSeconds(seconds);
			Spawning(angle, radius);
		}

		private void Spawning(float angle, float radius)
		{
			Vector2 offset = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.right) * radius;

			GameObject spawningObject = Instantiate(objectToSpawn);
			spawningObject.transform.position = targetPosition + offset;
			spawningObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
		}
	}
}