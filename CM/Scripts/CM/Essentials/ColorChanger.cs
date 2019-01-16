using UnityEngine;

namespace CM.Essentials
{
	public class ColorChanger : MonoBehaviour
	{
		public Color newColor;
		public float time;

		public delegate void ColorFinishHandler();
		public event ColorFinishHandler ColorFinishEvent;

		private SpriteRenderer _spriteRenderer;

		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void Update()
		{
			_spriteRenderer.color = Color.Lerp(_spriteRenderer.color, newColor, Time.deltaTime * time);

			if (_spriteRenderer.color == newColor)
				ColorFinishEvent?.Invoke();
		}
	}
}