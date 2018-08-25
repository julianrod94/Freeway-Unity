﻿using System.Collections;
using System.Collections.Generic;
using Standard_Assets;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

	public Canvas Idle;
	public Canvas Menu;
	public Canvas Game;
	public Canvas EndGame;

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

	private void DisableAll() {
		Idle.gameObject.SetActive(false);
		Menu.gameObject.SetActive(false);
		Game.gameObject.SetActive(false);
		EndGame.gameObject.SetActive(false);
	}
}