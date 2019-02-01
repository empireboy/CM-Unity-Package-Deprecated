using System.Collections;
using UnityEngine;

namespace CM.Music
{
	public class AudioPlayer : MonoBehaviour
	{
		private AudioSource _audioSource;
		public AudioSource AudioSource { get => _audioSource; }

		public bool IsPlaying { get => AudioSource.isPlaying; }

		public delegate void AudioInitializedHandler(AudioSource audioSource);
		public event AudioInitializedHandler AudioInitializedEvent;

		public void Play()
		{
			Stop();
			AudioSource.Play();
			StopAllCoroutines();
		}

		public void PlayAudioAt(float audioTime, float time)
		{
			Stop();
			AudioSource.time = audioTime;
			Play();
			StartCoroutine(PlayAudioAtRoutine(time));
		}

		public void PlayAudioAt(float audioTime)
		{
			Stop();
			AudioSource.time = audioTime;
			Play();
			StopAllCoroutines();
		}

		public void Stop()
		{
			AudioSource.Stop();
			StopAllCoroutines();
		}

		public void SetAudio(AudioData audioData)
		{
			if (!AudioSource)
				_audioSource = gameObject.AddComponent<AudioSource>();

			AudioSource.clip = audioData.clip;
			AudioSource.volume = audioData.volume;
			AudioSource.pitch = audioData.pitch;
			AudioSource.playOnAwake = audioData.playOnAwake;

			AudioInitializedEvent?.Invoke(AudioSource);
		}

		private IEnumerator PlayAudioAtRoutine(float time)
		{
			yield return new WaitForSeconds(time);
			Stop();
		}
	}
}