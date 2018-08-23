using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Standard_Assets
{
    public enum CarDirection {
        Left,Right
    }
    
    public class Car : MonoBehaviour {

        public CarDirection Direction;      
 
        private float _currentSpeed;
        private int _limit;
        private float _initialSpeed;

        private Vector3 InitialPosition {
            get {
                float border;
                if (Direction == CarDirection.Left) {
                    border = GameConstants.World.OutsideRightBound;
                } else {
                    border = GameConstants.World.OutsideLeftBound;
                }
                
                return new Vector3(border, transform.position.y, 0);
            }
        }

        // Use this for initialization
        void Start ()
        {
            
            if (Direction == CarDirection.Left) {
                _initialSpeed = -GameConstants.Car.InitialSpeed;
            } else {
                _initialSpeed = GameConstants.Car.InitialSpeed;

            }
            _currentSpeed = _initialSpeed;

            transform.position = InitialPosition;
        }
	
        // Update is called once per frame
        void Update() {		
            var x = Time.deltaTime * _currentSpeed;
            transform.Translate(x, 0, 0);

            if (Random.value < GameConstants.Car.ChanceChangingSpeed) {
                _currentSpeed = _initialSpeed * (0.8f + Random.value * 0.4f);
            }

            if (Direction == CarDirection.Right && transform.position.x > GameConstants.World.OutsideRightBound) {
                transform.position = InitialPosition;
            }
            else if (Direction == CarDirection.Left && transform.position.x < GameConstants.World.OutsideLeftBound) {
                transform.position = InitialPosition;
            }
        }
    }
}