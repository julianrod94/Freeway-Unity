using UnityEngine;

namespace Standard_Assets {
    public enum Player {
        Player1,
        Player2
    };
    
    public class GameConstants: MonoBehaviour {
        
        //World
        public static class World {
            public static float OutsideLeftBound;
            public static float OutsideRightBound;
            
            public static void Calculate() {
                var vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
                var horzExtent = vertExtent * Screen.width / Screen.height;
                OutsideRightBound = horzExtent * 1.2f;
                OutsideLeftBound = -OutsideRightBound;
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
            public static float Speed  = -0.08f;
            public static float RotationSpeed = -15f;
        }
        
        //Car
        public static class Car {
            public static float InitialSpeed = 2f;
            public static float ChanceChangingSpeed = 0.01f;
        }

        private void Awake() {
            Controlable.Calculate();  
            World.Calculate();
        }
    }
}