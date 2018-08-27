using UnityEngine;
using UnityEngine.EventSystems;

public class TouchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public bool IsPressed;

	public void OnPointerDown(PointerEventData eventData) {
		IsPressed = true;
	}

	public void OnPointerUp(PointerEventData eventData) {
		IsPressed = false;
	}
}
