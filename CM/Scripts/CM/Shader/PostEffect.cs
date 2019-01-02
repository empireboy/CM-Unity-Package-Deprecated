using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CM.Shader
{
	public class PostEffect : MonoBehaviour
	{
		[SerializeField] private Material _material;

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			Graphics.Blit(source, destination, _material);
		}
	}
}