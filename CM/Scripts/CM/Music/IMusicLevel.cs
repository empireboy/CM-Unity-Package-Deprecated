using UnityEngine;

namespace CM.Music
{
	public interface IMusicLevel
	{
		int GetBpm();
		AudioClip GetAudioClip();
		float GetAudioVolume();
		float GetAudioPitch();
	}
}