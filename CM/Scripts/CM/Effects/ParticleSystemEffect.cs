using UnityEngine;

namespace CM.Effects
{
	public class ParticleSystemEffect : MonoBehaviour, IEffect
	{
		[SerializeField]
		private ParticleSystem _particleSystem;

		public void Play()
		{
			_particleSystem.Play();
		}
	}
}
