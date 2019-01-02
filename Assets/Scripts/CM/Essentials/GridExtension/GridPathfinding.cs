using UnityEngine;

namespace CM.Essentials.GridExtension
{
	public class Pathfinding<T> : GridExt
	{
		private T[,] _grid;

		private Vector2 _startPoint;
		private Vector2 _endPoint;

		private bool _finished;

		public Pathfinding(T[,] grid, Vector2 startPoint, Vector2 endPoint)
		{
			_grid = grid;
			_startPoint = startPoint;
			_endPoint = endPoint;
		}

		private void Update()
		{
			if (!_finished)
				PathfindingUpdate();
		}

		private void PathfindingUpdate()
		{

		}
	}
}