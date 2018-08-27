using UnityEngine;
using UnityEngine.UI;

namespace Standard_Assets.Scripts {
    public class LevelScoreManager: MonoBehaviour {
        
        public Text TextScoreP1;
        public Text TextScoreP2;

        public void Update() {
            TextScoreP1.text = ScoreManager.Instance.P1Score.ToString();
            TextScoreP2.text = ScoreManager.Instance.P2Score.ToString();
        }
    }
}

