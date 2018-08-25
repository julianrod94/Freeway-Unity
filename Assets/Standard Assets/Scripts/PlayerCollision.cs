using UnityEngine;

namespace Standard_Assets {
    public class PlayerCollision : MonoBehaviour {
        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("Car")) {
                gameObject.GetComponent<PlayerController>().CrashWithCar();
            }
        }
    }
}
