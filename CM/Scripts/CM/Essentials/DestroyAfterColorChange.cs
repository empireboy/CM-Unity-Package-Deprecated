using UnityEngine;

namespace CM.Essentials
{
	public class DestroyAfterColorChange : MonoBehaviour
	{
		private void Awake()
		{
			GetComponent<ColorChanger>().ColorFinishEvent += OnColorFinish;
		}

		private void OnColorFinish()
		{
			Destroy(gameObject);
		}
	}
}