using System;
using UnityEngine;

namespace Standard_Assets.Scripts {
    public enum Player {
        Player1,
        Player2
    };
    
    public class GameConstants: MonoBehaviour {
        
        //World
        public static class World {
            public static float OutsideLeftBound;
            public static float OutsideRightBound;
            public static float OutsideBoundSize;
            public static float Width;
            public static float Height;
            
            public static void Calculate() {
                var vertExtent = Camera.main.orthographicSize;
                var horzExtent = vertExtent * Camera.main.aspect;
                OutsideRightBound = horzExtent * 1.2f;
                OutsideLeftBound = -OutsideRightBound;
                OutsideBoundSize = OutsideRightBound * 2;
                Width = horzExtent * 2;
                Height = vertExtent * 2;
            }
        }

        //FreeWay
        public static class FreeWay {
            public static float UpperBound;
            public static float LowerBound;
            public static float Height;
            public static float LaneHeight;
            public static float CarHeight;
            
            public static void Calculate() {
                LaneHeight = World.Height / 12f;
                Height = LaneHeight * 10;
                UpperBound = Height / 2f - LaneHeight;
                LowerBound = -Height / 2f + LaneHeight;
                CarHeight = LaneHeight * 0.8f;
            }
        }
       
        //Player
        public static class Player {
            public static float Speed = 2f;
        }
        
        //Controlable
        public static class Controlable {
            public static float LowerBound;
            public static float UpperBound;

            public static void Calculate() {
                var bounds = Camera.main.GetComponent<Camera>().orthographicSize * 0.85f;
                LowerBound = -bounds;
                UpperBound = bounds;
            }
        }

        //Crash
        public static class Crash {
            public static float Time  = 0.7f;
            public static float Speed  = -2f;
            public static float RotationSpeed = -500f;
        }
        
        //Car
        public static class Car {
            public static float InitialSpeed;
            public static float ChanceChangingSpeed = 0.005f;

            public static void Calculate() {
                InitialSpeed = World.Width / 8.0f;
            }
        }

        private void Awake() {
            World.Calculate();
            Controlable.Calculate();  
            FreeWay.Calculate();
            Car.Calculate();
        }
    }
}