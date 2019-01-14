using UnityEngine;

namespace CM.Essentials
{
	public class SpriteFader : MonoBehaviour
	{
		public float reduceValue = 0.01f;

		public delegate void FadeFinishHandler();
		public event FadeFinishHandler fadeFinishEvent;

		private SpriteRenderer spriteRenderer;

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void Update()
		{
			Color color = spriteRenderer.color;
			color.a -= reduceValue;
			spriteRenderer.color = color;

			if (color.a <= 0)
				fadeFinishEvent();
		}
	}
}