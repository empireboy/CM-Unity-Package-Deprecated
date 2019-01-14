using UnityEngine;

namespace CM.Essentials
{
	public class SetMouseTexture : MonoBehaviour
	{
		public Texture2D cursorTexture;

		private void Awake()
		{
			Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width/2, cursorTexture.height/2), CursorMode.Auto);
		}
	}
}