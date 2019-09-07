using UnityEngine;
using CM.Orientation;

namespace CM
{
	public static class CM_CameraExtension
	{
		public static float GetWidth(this Camera camera)
		{
			return 2f * camera.orthographicSize * camera.aspect;
		}

		public static float GetHeight(this Camera camera)
		{
			return camera.orthographicSize * 2f;
		}

		public static Vector3 GetWorldCenter(this Camera camera)
		{
			return camera.ScreenToWorldPoint(camera.GetScreenCenter());
		}

		public static Vector3 GetScreenCenter(this Camera camera)
		{
			return new Vector3(Screen.width / 2, Screen.height / 2, camera.nearClipPlane);
		}

		public static Vector3 GetScreenBorderPoint(this Camera camera, Direction direction)
		{
			Vector3 position = Vector3.zero;
			Vector3 center = camera.GetWorldCenter();
			float width = camera.GetWidth();
			float height = camera.GetHeight();

			switch (direction)
			{
				case Direction.Left:
					position = new Vector3(center.x - width / 2, center.y, camera.nearClipPlane);
					break;
				case Direction.Right:
					position = new Vector3(center.x + width / 2, center.y, camera.nearClipPlane);
					break;
				case Direction.Top:
					position = new Vector3(center.x, center.y + height / 2, camera.nearClipPlane);
					break;
				case Direction.Bottom:
					position = new Vector3(center.x, center.y - height / 2, camera.nearClipPlane);
					break;
			}

			return position;
		}

		public static Vector3 GetScreenBorderPoint(this Camera camera, DiagonalDirection direction)
		{
			Vector3 position = Vector3.zero;
			Vector3 center = camera.GetWorldCenter();
			float width = camera.GetWidth();
			float height = camera.GetHeight();

			switch (direction)
			{
				case DiagonalDirection.Topleft:
					position = new Vector3(center.x - width / 2, center.y + height / 2, camera.nearClipPlane);
					break;
				case DiagonalDirection.Topright:
					position = new Vector3(center.x + width / 2, center.y + height / 2, camera.nearClipPlane);
					break;
				case DiagonalDirection.Bottomleft:
					position = new Vector3(center.x - width / 2, center.y - height / 2, camera.nearClipPlane);
					break;
				case DiagonalDirection.Bottomright:
					position = new Vector3(center.x + width / 2, center.y - height / 2, camera.nearClipPlane);
					break;
			}

			return position;
		}

		public static Vector3 GetWorldBorderPoint(this Camera camera, Direction direction)
		{
			return camera.GetScreenBorderPoint(direction);
		}

		public static Vector3 GetWorldBorderPoint(this Camera camera, DiagonalDirection direction)
		{
			return camera.GetScreenBorderPoint(direction);
		}
	}
}