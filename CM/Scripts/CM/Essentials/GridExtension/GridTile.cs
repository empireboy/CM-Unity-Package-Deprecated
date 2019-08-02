using UnityEngine;
using NaughtyAttributes;

namespace CM.Essentials.GridExtension
{
	public class GridTile : GridExt
	{
		[ShowNonSerializedField] private Vector2 _gridPosition;
		public Vector2 GridPosition
		{
			get
			{
				return _gridPosition;
			}
		}

		private object _type = null;
		public object Type
		{
			get
			{
				return _type;
			}
		}

		public void SetGridPosition(Vector2 gridPosition)
		{
			_gridPosition = gridPosition;
		}

		public void SetType<T>(T type)
		{
			_type = type;
		}
	}
}