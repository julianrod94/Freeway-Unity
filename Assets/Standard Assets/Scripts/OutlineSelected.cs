using System.Collections;
using System.Collections.Generic;
using Standard_Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Standard_Assets.Scripts {

	public class OutlineSelected : MonoBehaviour {

		public Player player;
		public Difficulty Difficulty;

		private Outline _outline;

		void Start() {
			_outline = GetComponent<Outline>();
		}

		// Update is called once per frame
		void Update() {
			switch (player) {
				case Player.Player1:
					_outline.enabled = GameManager.Instance.P1Difficulty == Difficulty;
					break;
				
				case Player.Player2:
					_outline.enabled = GameManager.Instance.P2Difficulty == Difficulty;
					break;
			}
		}
	}
}
