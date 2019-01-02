using UnityEngine;

namespace CM.Essentials.Audio
{
	public class PlayAudio : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;

		public void Play()
		{
			_audioSource.Play();
		}
	}
}