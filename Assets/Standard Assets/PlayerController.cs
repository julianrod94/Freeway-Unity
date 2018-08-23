using System;
using UnityEngine;

namespace Standard_Assets {
    public class PlayerController : MonoBehaviour {
        public Player Player;
        public bool CanControl;

        private Vector3 _initialPosition;
        private String _axis;

        // Use this for initialization
        void Start() {
            CanControl = true;
            _initialPosition = transform.position;
            
            if (Player == Player.Player1) {
                _axis = "P1_Vertical";
            } else {
                _axis = "P2_Vertical";
            }
        }

        // Update is called once per frame
        void Update() {
            if (CanControl){
                var y = Input.GetAxis(_axis) * Time.deltaTime * GameConstants.Player.Speed;
                transform.Translate(0, y, 0);
                var newY = Mathf.Clamp(
                    transform.position.y,
                    GameConstants.Controlable.LowerBound,
                    GameConstants.Controlable.UpperBound
                );
                
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
        }

        public void ResetPosition() {
            transform.position = _initialPosition;
        }

        public void CrashWithCar() {
            gameObject.GetComponent<PlayerController>().CanControl = false;

            var playerCrashing = gameObject.GetComponent<PlayerCrashing>();
            if (playerCrashing == null) {
                gameObject.AddComponent<PlayerCrashing>();
            } else {
                playerCrashing.AddTime();
            }
        }
    }
}