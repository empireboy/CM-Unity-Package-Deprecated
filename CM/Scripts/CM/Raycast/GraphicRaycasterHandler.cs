using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using NaughtyAttributes;

public class GraphicRaycasterHandler : MonoBehaviour
{
	public delegate void MousePressedHandler(GameObject hit, int mouseButton);
	public event MousePressedHandler MousePressedEvent;
	public delegate void MouseReleasedHandler(GameObject hit, int mouseButton);
	public event MouseReleasedHandler MouseReleasedEvent;
	public delegate void MouseDownHandler(GameObject hit, int mouseButton);
	public event MouseDownHandler MouseDownEvent;
	public delegate void SelectHandler(GameObject hit, int mouseButton);
	public event SelectHandler SelectEvent;

	private GraphicRaycaster _graphicRaycaster;
	private PointerEventData _pointerEventData;
	private EventSystem _eventSystem;

	private GameObject _previousObject = null;

	private int _mouseButtonCount = 2;

	[Dropdown("_mouseEvents")]
	[SerializeField] private string _selectOnMouse;

	private string[] _mouseEvents = new string[]
	{
		"pressed",
		"release"
	};

	private void Awake()
	{
		_graphicRaycaster = GetComponent<GraphicRaycaster>();
		_eventSystem = GetComponent<EventSystem>();
	}

	private void Update()
	{
		_pointerEventData = new PointerEventData(_eventSystem);
		_pointerEventData.position = Input.mousePosition;

		List<RaycastResult> results = new List<RaycastResult>();

		_graphicRaycaster.Raycast(_pointerEventData, results);

		// Mouse Pressed on Raycast Object
		for (int i = 0; i < _mouseButtonCount; i++)
		{
			if (Input.GetMouseButtonDown(i))
			{
				foreach (RaycastResult result in results)
				{
					if (MousePressedEvent != null)
					{
						MousePressedEvent(result.gameObject, i);
						if (_previousObject != null)
							MousePressedEvent(_previousObject, i);
					}

					// If you want to select this object on mouse pressed
					if (_selectOnMouse == "pressed")
					{
						if (SelectEvent != null)
							SelectEvent(result.gameObject, i);

						_previousObject = null;
					}
				}
			}
		}

		// Mouse Released on Raycast Object
		for (int i = 0; i < _mouseButtonCount; i++)
		{
			if (Input.GetMouseButtonUp(i))
			{
				foreach (RaycastResult result in results)
				{
					if (MouseReleasedEvent != null)
					{
						MouseReleasedEvent(result.gameObject, i);
						if (_previousObject != null)
							MouseReleasedEvent(_previousObject, i);
					}

					// If you want to select this object on mouse release
					if (_selectOnMouse == "release")
					{
						if (SelectEvent != null)
							SelectEvent(result.gameObject, i);

						_previousObject = null;
					}
				}
			}
		}

		// Mouse Down on Raycast Object
		for (int i = 0; i < _mouseButtonCount; i++)
		{
			if (Input.GetMouseButton(i))
			{
				foreach (RaycastResult result in results)
				{
					if (MouseDownEvent != null)
						MouseDownEvent(result.gameObject, i);

					if (result.gameObject != _previousObject && _previousObject != null)
					{
						if (MouseReleasedEvent != null)
							MouseReleasedEvent(_previousObject, i);
					}

					_previousObject = result.gameObject;
				}
			}
		}

		// Quick check for if there is no raycast object detected
		for (int i = 0; i < _mouseButtonCount; i++)
		{
			if (results.Count <= 0 && _previousObject != null)
			{
				if (MouseReleasedEvent != null)
					MouseReleasedEvent(_previousObject, i);

				_previousObject = null;
			}
		}
	}
}