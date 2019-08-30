using CM.Effects;
using CM.Spawner;
using UnityEngine;

public class Spawning : MonoBehaviour, ISpawning
{
	[SerializeField]
	private Transform _transformToSpawn;

	[SerializeField]
	private Transform _spawnPoint;

	public void Spawn()
	{
		if (!_spawnPoint)
			return;

		_transformToSpawn.position = _spawnPoint.position;

		// Spawn Effect
		IEffect spawnEffect = GetComponent<IEffect>();

		if (spawnEffect != null)
			spawnEffect.Play();
	}

	public void SetSpawn(Transform spawnPoint)
	{
		_spawnPoint = spawnPoint;
	}
}