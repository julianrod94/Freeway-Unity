using System;
using UnityEngine;

namespace Standard_Assets.Scripts {
    public class PlayerController : MonoBehaviour {
        public Player Player;
        
        private bool _canControl;
        private Vector3 _initialPosition;
        private String _axis;
        private AxisProvider _axisProvider;
        

        // Use this for initialization
        void Start() {
            _canControl = true;
            _initialPosition = transform.position;
            
            if (Player == Player.Player1) {
                _axis = "P1_Vertical";
            } else {
                _axis = "P2_Vertical";
            }

            if (GameManager.Instance.IsMobile) {
                _axisProvider = FindObjectOfType<TouchAxis>();                
            } else {
                _axisProvider = new NormalAxis();
            }
        }

        // Update is called once per frame
        void Update() {
            if (GameManager.Instance.State != GameState.Playing) {
                transform.position = _initialPosition;
                return;
            }
            
            if (_canControl){
                var y = _axisProvider.GetAxis(_axis) * Time.deltaTime * GameConstants.Player.Speed;
                
                GetComponent<Animator>().SetBool("walking", y!=0);
                
                transform.Translate(0, y, 0);
                var newY = Mathf.Clamp(
                    transform.position.y,
                    GameConstants.Controlable.LowerBound,
                    GameConstants.Controlable.UpperBound
                );
                
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
                
                
                if (Mathf.Approximately(transform.position.y, GameConstants.Controlable.UpperBound)) {
                    ScoreManager.Instance.Score(Player);
                    gameObject.GetComponent<PlayerController>().ResetPosition();
                }
            }
        }

        public void ResetPosition() {
            transform.position = _initialPosition;
        }

        public void SetControl(bool control) {
            _canControl = control;
        }

        public void CrashWithCar() {
            var playerCrashing = gameObject.GetComponent<PlayerCrashing>();
            if (playerCrashing == null) {
                gameObject.AddComponent<PlayerCrashing>();
            } else {
                playerCrashing.AddTime();
            }
        }
    }
}