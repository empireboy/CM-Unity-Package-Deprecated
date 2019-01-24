using System.Collections;
using UnityEngine;

namespace CM.Music
{
	public class AudioPlayer : MonoBehaviour
	{
		public AudioSource audioSource;

		public bool IsPlaying { get => audioSource.isPlaying; }

		public void Play()
		{
			Stop();
			audioSource.Play();
			StopAllCoroutines();
		}

		public void PlayAudioAt(float audioTime, float time)
		{
			Stop();
			audioSource.time = audioTime;
			Play();
			StartCoroutine(PlayAudioAtRoutine(time));
		}

		public void PlayAudioAt(float audioTime)
		{
			Stop();
			audioSource.time = audioTime;
			Play();
			StopAllCoroutines();
		}

		public void Stop()
		{
			audioSource.Stop();
			StopAllCoroutines();
		}

		public void SetAudio(AudioData audioData)
		{
			if (!audioSource)
				audioSource = gameObject.AddComponent<AudioSource>();

			audioSource.clip = audioData.clip;
			audioSource.volume = audioData.volume;
			audioSource.pitch = audioData.pitch;
			audioSource.playOnAwake = audioData.playOnAwake;
		}

		private IEnumerator PlayAudioAtRoutine(float time)
		{
			yield return new WaitForSeconds(time);
			Stop();
		}
	}

	public struct AudioData
	{
		public AudioClip clip;
		public float volume;
		public float pitch;
		public bool playOnAwake;
	}
}