using UnityEngine;

namespace Standard_Assets {
    public class PlayerCollision : MonoBehaviour {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Car")) {
                gameObject.GetComponent<PlayerController>().CrashWithCar();
            }
        
            if (other.gameObject.CompareTag("Goal")) {
                var player = gameObject.GetComponent<PlayerController>().Player;
                ScoreManager.Instance.Score(player);
                gameObject.GetComponent<PlayerController>().ResetPosition();
            }
        }
    }
}
