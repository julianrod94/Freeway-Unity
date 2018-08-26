using UnityEngine;

namespace Standard_Assets.Scripts {
    public class CarCoordinator: MonoBehaviour {
        public float[] LaneVelocities = new float[10];

        private static CarCoordinator _instance;
        public static CarCoordinator Instance {
            get { return _instance ?? (_instance = new CarCoordinator()); }
            private set { _instance = value; }
        }

        public CarCoordinator() {
            CarCoordinator._instance = this;
        }

        void Start() {
            LevelManager.SetLevel(0);
            for (int i = 0; i < 10; i++) {
                LaneVelocities[i] = GameConstants.Car.InitialSpeed * (0.8f + Random.value * 0.4f);
            }
        }

        private void LateUpdate() {
            for (int i = 0; i < 10; i++) {
                if (Random.value < GameConstants.Car.ChanceChangingSpeed) {
                    LaneVelocities[i] = LaneVelocities[i] * (0.8f + Random.value * 0.4f);
                }
            }
        }
    }
}