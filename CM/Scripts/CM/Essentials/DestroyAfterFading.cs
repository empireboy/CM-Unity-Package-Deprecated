using UnityEngine;

namespace CM.Essentials
{
	public class DestroyAfterFading : MonoBehaviour
	{
		private void Awake()
		{
			GetComponent<SpriteFader>().fadeFinishEvent += OnFadeFinish;
		}

		private void OnFadeFinish()
		{
			Destroy(gameObject);
		}
	}
}