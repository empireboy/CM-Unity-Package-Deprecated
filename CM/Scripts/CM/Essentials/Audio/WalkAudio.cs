using UnityEngine;
using CM.Orientation;

namespace CM.Essentials.Audio
{
	public class WalkAudio : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;
		[SerializeField] private MovementBase _movement;
		[SerializeField] private Animator _animator;
		[SerializeField] private float _stopAudioSpeed = 1f;

		[Header("Animation States")]
		[SerializeField] private string _walkState = "Walk";

		private bool _isStopping = false;
		private float _audioVolume;

		private void Start()
		{
			_audioVolume = _audioSource.volume;
		}

		private void Update()
		{
			if (_audioSource.isPlaying && !_animator.GetCurrentAnimatorStateInfo(0).IsName(_walkState) && !_movement.IsMoving)
				_isStopping = true;

			if (_isStopping)
			{
				_audioSource.volume -= Time.deltaTime * _stopAudioSpeed;

				if (_audioSource.volume <= 0)
				{
					_audioSource.Stop();
					_isStopping = false;
					_audioSource.volume = _audioVolume;
				}
			}
		}

		public void PlayWalkAudio()
		{
			_audioSource.Play();
		}
	}
}