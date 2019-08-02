using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials.GridExtension
{
	public class GridNeighbours<T>
	{
		private T[,] _grid;
		public T[,] Grid
		{
			get
			{
				return _grid;
			}
		}

		private Vector2[] _neighboursPositions = new Vector2[]
		{
			new Vector2(-1, 0),
			new Vector2(1, 0),
			new Vector2(0, -1),
			new Vector2(0, 1),
			new Vector2(1, 1),
			new Vector2(1, -1),
			new Vector2(-1, 1),
			new Vector2(-1, -1)
		};

		private Vector2 _tilePosition;
		public Vector2 TilePosition
		{
			get
			{
				return _tilePosition;
			}
		}

		public GridNeighbours(Vector2 tilePosition, T[,] grid)
		{
			_tilePosition = tilePosition;
			_grid = grid;
		}

		public List<T> GetNeighbours4(int row)
		{
			List<T> currentNeighbours = new List<T>();

			for (int i = 0; i < 4; i++)
			{
				Vector2 tilePosition = new Vector2(_tilePosition.x + _neighboursPositions[i].x * row, _tilePosition.y + _neighboursPositions[i].y * row);

				if (GridExt.IsInRange(_grid, tilePosition))
				{
					currentNeighbours.Add(_grid[(int)tilePosition.x, (int)tilePosition.y]);
				}
				else
				{
					currentNeighbours.Add(default(T));
				}
			}

			return currentNeighbours;
		}

		public List<T> GetNeighbours8(int row)
		{
			List<T> currentNeighbours = new List<T>();

			for (int i = 0; i < 8; i++)
			{
				Vector2 tilePosition = new Vector2(_tilePosition.x + _neighboursPositions[i].x * row, _tilePosition.y + _neighboursPositions[i].y * row);

				if (GridExt.IsInRange(_grid, tilePosition))
				{
					currentNeighbours.Add(_grid[(int)tilePosition.x, (int)tilePosition.y]);
				}
				else
				{
					currentNeighbours.Add(default(T));
				}
			}

			return currentNeighbours;
		}

		public List<T> GetNeighboursInLine(int neighbourIndex, int rows)
		{
			List<T> currentNeighbours = new List<T>();

			for (int i = 1; i < rows + 1; i++)
			{
				Vector2 tilePosition = new Vector2(_tilePosition.x + _neighboursPositions[neighbourIndex].x * i, _tilePosition.y + _neighboursPositions[neighbourIndex].y * i);

				if (GridExt.IsInRange(_grid, tilePosition))
				{
					currentNeighbours.Add(_grid[(int)tilePosition.x, (int)tilePosition.y]);
				}
				else
				{
					currentNeighbours.Add(default(T));
				}
			}

			return currentNeighbours;
		}

		public T GetNeighbour(Vector2 position)
		{
			return _grid[(int)_tilePosition.x + (int)position.x, (int)_tilePosition.y + (int)position.y];
		}

		public T GetNeighbour(int neighbourIndex, int row)
		{
			return _grid[(int)_tilePosition.x + ((int)_neighboursPositions[neighbourIndex].x * row), (int)_tilePosition.y + ((int)_neighboursPositions[neighbourIndex].y * row)];
		}

		public Vector2 GetNeighboursPosition(int neighbourIndex)
		{
			return new Vector2(_neighboursPositions[neighbourIndex].x, _neighboursPositions[neighbourIndex].y);
		}

		public Vector2 GetNeighboursPosition(int neighbourIndex, int row)
		{
			return new Vector2(_neighboursPositions[neighbourIndex].x * row, _neighboursPositions[neighbourIndex].y * row);
		}
	}
}