using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials
{
	public class SpriteFader : MonoBehaviour
	{
		public float reduceValue = 0.01f;

		private SpriteRenderer spriteRenderer;

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void Update()
		{
			Color color = spriteRenderer.color;
			color.a -= reduceValue;
			spriteRenderer.color = color;


		}
	}
}