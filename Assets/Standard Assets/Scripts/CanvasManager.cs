using System.Collections;
using System.Collections.Generic;
using Standard_Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

	public Canvas Idle;
	public Canvas Menu;
	public Canvas Game;
	public Canvas EndGame;

	public Text LevelLabel;
	public Text TimeLabel;

	void Awake() {
		DisableAll();	
	}

	// Update is called once per frame
	void Update () {
		switch (GameManager.Instance.State) {
			case GameState.Idle:
				if (!Idle.gameObject.activeSelf) {
					DisableAll();
					Idle.gameObject.SetActive(true);
				}
				break;
				
			case GameState.Menu:
				UpdateMenuLabels();
				if (!Menu.gameObject.activeSelf) {
					DisableAll();
					Menu.gameObject.SetActive(true);
				}
				break;
				
			case GameState.Playing:
				if (!Game.gameObject.activeSelf) {
					DisableAll();
					Game.gameObject.SetActive(true);
				}
				break;
			
			case GameState.Score:
				if (!EndGame.gameObject.activeSelf) {
					DisableAll();
					EndGame.gameObject.SetActive(true);
				}
				break;
		}
	}

	public void ToMenu() {
		GameManager.Instance.State = GameState.Menu;
	}

	public void PlayGame() {
		GameManager.Instance.State = GameState.Playing;
	}

	public void SetHardDifficulty(bool player1) {
		if (player1) {
			GameManager.Instance.P1Difficulty = Difficulty.Hard;
		} else {
			GameManager.Instance.P2Difficulty = Difficulty.Hard;
		}
	}
	
	public void SetEasyDifficulty(bool player1) {
		if (player1) {
			GameManager.Instance.P1Difficulty = Difficulty.Easy;
		} else {
			GameManager.Instance.P2Difficulty = Difficulty.Easy;
		}
	}

	private void DisableAll() {
		Idle.gameObject.SetActive(false);
		Menu.gameObject.SetActive(false);
		Game.gameObject.SetActive(false);
		EndGame.gameObject.SetActive(false);
	}

	public void AddLevel() {
		GameManager.Instance.AddLevel();
	}
	
	public void RemoveLevel() {
		GameManager.Instance.RemoveLevel();
	}
	
	public void AddTime() {
		GameManager.Instance.AddTime();
	}
	
	public void RemoveTime() {
		GameManager.Instance.RemoveTime();
	}


	private void UpdateMenuLabels() {
		int level = GameManager.Instance.Level;

		if (level == 0) {
			LevelLabel.text = "?";			
		} else {
			LevelLabel.text = GameManager.Instance.Level.ToString();
		}
		
		TimeLabel.text = GameManager.Instance.Time.ToString();
	}
}
