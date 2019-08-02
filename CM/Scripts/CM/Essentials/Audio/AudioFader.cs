using CM.Essentials.Interpolation;
using UnityEngine;

namespace CM.Essentials
{
	[RequireComponent(typeof(AudioSource))]
	public class AudioFader : FloatFader<AudioSource>
	{
		public override void FadeIn()
		{
			base.FadeIn();

			component.Play();
		}

		protected override void OnFadeOutFinish()
		{
			base.OnFadeOutFinish();

			component.Stop();
		}

		protected override float GetComponentValue()
		{
			return component.volume;
		}

		protected override void SetComponentValue(float value)
		{
			component.volume = value;
		}
	}
}