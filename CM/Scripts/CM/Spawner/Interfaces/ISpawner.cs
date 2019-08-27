using UnityEngine;

namespace CM.Spawner
{
	public interface ISpawning
	{
		void Spawn();
		void SetSpawn(Transform spawnPoint);
	}
}