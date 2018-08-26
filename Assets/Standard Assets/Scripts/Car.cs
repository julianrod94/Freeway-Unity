using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Standard_Assets.Scripts
{
    public enum CarDirection {
        Left,Right
    }
    
    public class Car : MonoBehaviour {

        public int Lane;
        private CarDirection _direction;

        public CarDirection Direction {
            get { return _direction; }
            set {
                transform.rotation = value == CarDirection.Right ? Quaternion.identity : Quaternion.Euler(0,0,180);
                _direction = value;
            }
        }      
 
        [SerializeField]
        private float _currentSpeed;
        private int _limit;
        private float _initialSpeed;

        private Vector3 InitialPosition {
            get {
                var border = 
                    Direction == CarDirection.Left 
                        ? GameConstants.World.OutsideRightBound : GameConstants.World.OutsideLeftBound;
                
                return new Vector3(border, transform.position.y, 0);
            }
        }

        // Use this for initialization
        void Start (){
            _initialSpeed = -GameConstants.Car.InitialSpeed;
            _currentSpeed = _initialSpeed;
        }
	
        // Update is called once per frame
        void Update() {
            _currentSpeed = CarCoordinator.Instance.LaneVelocities[Lane];
            
            var x = Time.deltaTime * _currentSpeed;
            transform.Translate(x, 0, 0);

            if (Direction == CarDirection.Right && transform.position.x > GameConstants.World.OutsideRightBound) {
                transform.position = InitialPosition;
            }
            else if (Direction == CarDirection.Left && transform.position.x < GameConstants.World.OutsideLeftBound) {
                transform.position = InitialPosition;
            }
        }
    }
}