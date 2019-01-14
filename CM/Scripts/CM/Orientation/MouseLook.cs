using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace CM.Movement
{
	public class MouseLook : MonoBehaviour
	{
		public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
		public RotationAxes rotationAxes = RotationAxes.MouseXAndY;
		[SerializeField] private Vector2 _sensitivity = new Vector2(2f, 2f);
		private Vector2 _currentSensitivity;
		private Vector2 _sensitivityMultiplier = new Vector2(1, 1);
		[Header("Mouse Y Properties")]
		public bool clamp = true;
		[ShowIf("clamp")]
		public float clampYMin = -70;
		[ShowIf("clamp")]
		public float clampYMax = 70;
		public bool invertY = false;
		[Header("Mouse X Properties")]
		public bool invertX = false;
		[Header("Input")]
		[SerializeField] private string _horizontalAxes = "Mouse X";
		[SerializeField] private string _verticalAxes = "Mouse Y";

		private Vector2 rotation = new Vector2(0, 0);

		private void Start()
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;

			_currentSensitivity = _sensitivity;
		}

		private void Update()
		{
			Vector2 axes = new Vector2(Input.GetAxis(_horizontalAxes), Input.GetAxis(_verticalAxes));
			Vector2 invert = new Vector2
			{
				x = (invertX) ? -1 : 1,
				y = (invertY) ? -1 : 1
			};

			rotation.x += (axes.x * (_currentSensitivity.x * _sensitivityMultiplier.x)) * invert.x;
			rotation.y += (axes.y * (_currentSensitivity.y * _sensitivityMultiplier.y)) * invert.y;

			if (clamp)
			{
				rotation.y = Mathf.Clamp(rotation.y, clampYMin, clampYMax);
			}

			switch (rotationAxes)
			{
				case RotationAxes.MouseXAndY:
					transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
					break;
				case RotationAxes.MouseX:
					transform.localEulerAngles = new Vector3(0, rotation.x, 0);
					break;
				case RotationAxes.MouseY:
					transform.localEulerAngles = new Vector3(rotation.y, 0, 0);
					break;
			}
		}

		public void SetSensitivity(Vector2 sensivity)
		{
			_currentSensitivity = sensivity;
		}

		public void SetSensitivityX(float sensivity)
		{
			_currentSensitivity.x = sensivity;
		}

		public void SetSensitivityY(float sensivity)
		{
			_currentSensitivity.y = sensivity;
		}

		public void ResetSensitivity()
		{
			_currentSensitivity = _sensitivity;
		}

		public void SetSensitivityMultiplier(Vector2 sensitivityMultiplier)
		{
			_sensitivityMultiplier = sensitivityMultiplier;
		}

		public void SetSensitivityMultiplierX(float sensitivityMultiplier)
		{
			_sensitivityMultiplier.x = sensitivityMultiplier;
		}

		public void SetSensitivityMultiplierY(float sensitivityMultiplier)
		{
			_sensitivityMultiplier.y = sensitivityMultiplier;
		}

		public void ResetSensitivityMultiplier()
		{
			_sensitivityMultiplier = new Vector2(1, 1);
		}
	}
}