using UnityEngine;

namespace CM.Music
{
	[System.Serializable]
	public struct AudioData
	{
		public AudioClip clip;
		[Range(0, 1)]
		public float volume;
		[Range(0, 2)]
		public float pitch;
		public bool playOnAwake;
	}
}