using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Car")
        {
            gameObject.GetComponent<PlayerController>().CrashWithCar();
        }
        
        if (other.gameObject.tag == "Goal") {
            int player = gameObject.GetComponent<PlayerController>().player;
            ScoreManager.instance.Score(player);
            gameObject.GetComponent<PlayerController>().ResetPosition();
        }
    }
}
