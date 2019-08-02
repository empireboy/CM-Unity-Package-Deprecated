using UnityEngine;

namespace CM.Essentials.GridExtension
{
	public class GridExt : MonoBehaviour
	{
		public static bool IsInRange<T>(T[,] grid, Vector2 tilePosition)
		{
			if (
				tilePosition.x < grid.GetLength(0) &&
				tilePosition.x >= 0 &&
				tilePosition.y < grid.GetLength(1) &&
				tilePosition.y >= 0
			)
			{
				return true;
			}
			return false;
		}
	}
}