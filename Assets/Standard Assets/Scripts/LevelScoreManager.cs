using UnityEngine;
using UnityEngine.UI;

namespace Standard_Assets {
    public class LevelScoreManager: MonoBehaviour {
        
        public Text TextScoreP1;
        public Text TextScoreP2;
    
        private void Start() {
            ScoreManager.Instance.AddCallBack(() => {
                TextScoreP1.text = ScoreManager.Instance.P1Score.ToString();
                TextScoreP2.text = ScoreManager.Instance.P2Score.ToString();
            });
        }
    }
}

