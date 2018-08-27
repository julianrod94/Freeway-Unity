using System.Collections;
using System.Collections.Generic;
using Standard_Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

	public Text TimeLabel;
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.State == GameState.Playing) {
			GameManager.Instance.AdvanceTime(Time.deltaTime);
		}

		TimeLabel.text = Mathf.CeilToInt(GameManager.Instance.Time).ToString();

	}
}
