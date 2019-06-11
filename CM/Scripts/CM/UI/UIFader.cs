using CM.Essentials.Timing;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CM.UI
{
	public class UIFader : MonoBehaviour
	{
		private Image _image;

		public TimeData fadeInTime;
		public TimeData fadeOutTime;

		private bool _isFading = false;
		private float _fadeTimer = 0.0f;
		private TimeData _totalFadeTime;

		private Color _startColor;
		private Color _endColor;

		public UnityEvent OnFadeFinish;

		private void Awake()
		{
			_image = GetComponent<Image>();
		}

		public void FadeTo(Color finalColor)
		{
			ResetVariables(finalColor);

			_isFading = true;
		}


		public void FadeIn()
		{
			Color color = _image.color;
			color.a = 1;
			_totalFadeTime = fadeInTime;
			FadeTo(color);
		}

		public void FadeOut()
		{
			Color color = _image.color;
			color.a = 0;
			_totalFadeTime = fadeOutTime;
			FadeTo(color);
		}

		public void StopFade()
		{
			_isFading = false;
		}

		private void ResetVariables(Color finalColor)
		{
			_fadeTimer = 0.0f;
			_startColor = _image.color;
			_endColor = finalColor;
		}

		private void Update()
		{
			if (_isFading)
			{
				_image.color = Color.Lerp(_startColor, _endColor, _fadeTimer / _totalFadeTime);
				if (_fadeTimer < _totalFadeTime)
				{
					_fadeTimer += Time.deltaTime;
				}
				else
				{
					OnFadeFinish.Invoke();
					_isFading = false;
				}
			}
		}
	}
}