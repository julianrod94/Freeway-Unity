using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Car")
        {
            gameObject.GetComponent<PlayerController>().canControl = false;
            gameObject.AddComponent<PlayerCrashing>();
        }
    }
}
