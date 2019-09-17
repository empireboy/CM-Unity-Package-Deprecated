using UnityEngine;

namespace CM.Essentials
{
	public abstract class ChainHealth : MonoBehaviour
	{
		[SerializeField]
		protected Health healthCaller;

		[SerializeField]
		protected Health healthReceiver;

		protected abstract void OnChain(float damage);
	}
}