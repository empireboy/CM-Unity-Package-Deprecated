using CM.Spawner;
using UnityEngine;

namespace CM.Effects
{
	public class SpawnEffect : MonoBehaviour, ISpawning
	{
		public void Spawn()
		{
			GetComponent<IEffect>().Play();
		}
	}
}