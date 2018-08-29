using UnityEngine;
using UnityEngine.UI;

namespace Standard_Assets.Scripts {
    public class LevelScoreManager: MonoBehaviour {
        
        public Text TextScoreP1;
        public Text TextScoreP2;

        public Image Player1Wins;
        public Image Player2Wins;
        public Image Draw;

        public void Update() {
            var p1Score = ScoreManager.Instance.P1Score;
            var p2Score = ScoreManager.Instance.P2Score;
            
            switch (GameManager.Instance.State) {
                case GameState.Playing:
                    TextScoreP1.text = p1Score.ToString();
                    TextScoreP2.text = p2Score.ToString();
                    break;
                case GameState.Score:
                    Player1Wins.enabled = p1Score > p2Score;
                    Player2Wins.enabled = p1Score < p2Score;
                    Draw.enabled = p1Score == p2Score;
                    break;
            }
            
        }
    }
}

