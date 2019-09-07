using UnityEngine;

namespace CM
{
	public static class CM_LayerMaskExtension
	{
		public static bool Contains(this LayerMask mask, int layer)
		{
			return mask == (mask | (1 << layer));
		}
	}
}