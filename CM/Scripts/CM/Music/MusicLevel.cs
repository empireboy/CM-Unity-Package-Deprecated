using System.Collections.Generic;
using UnityEngine;

namespace CM.Music
{
	[CreateAssetMenu(menuName = "CM/Music/New Music Level", fileName = "NewMusicLevel.asset")]
	public class MusicLevel : ScriptableObject
	{
		public int bpm;
		public AudioClip audio;
		public float audioVolume = 1;
		public float audioPitch = 1;
		public float cameraSize = 5;
		public List<Beat> beats;
	}
}