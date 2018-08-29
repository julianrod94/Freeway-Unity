using Standard_Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public bool IsPressed;

	public void OnPointerDown(PointerEventData eventData) {
		IsPressed = true;
	}

	public void OnPointerUp(PointerEventData eventData) {
		IsPressed = false;
	}

	private void Awake() {
		if (!GameManager.Instance.IsMobile) {
			Destroy(gameObject);
		}
	}
	private void Update() {
		var button = GetComponent<Button>();
		var colorBlockNormalColor = button.colors.normalColor;
		colorBlockNormalColor.a = button.colors.normalColor.a - 0.2f * Time.deltaTime;
		var buttonColors = button.colors;
		buttonColors.normalColor = colorBlockNormalColor;
		button.colors = buttonColors;
	}
}
