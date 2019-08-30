using UnityEngine;

namespace CM.Effects
{
	public class ParticleSystemEffect : MonoBehaviour, IEffect
	{
		[SerializeField]
		private ParticleSystem _particleSystem;

		public void Play()
		{
			ParticleSystem effect = Instantiate(_particleSystem, transform.position, Quaternion.identity);

			effect.Play();
		}
	}
}
