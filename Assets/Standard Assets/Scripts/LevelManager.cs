using UnityEngine;
using UnityEngine.UI;

namespace Standard_Assets.Scripts {

    enum Vehicle {
        Car,
        Truck,
        None
    }

    public class LevelManager {
        
        private static readonly Vehicle[][] Level1 = {
            new Vehicle[] {Vehicle.Car},
            new Vehicle[] {Vehicle.Car},
            new Vehicle[] {Vehicle.Car},
            new Vehicle[] {Vehicle.Car},
            new Vehicle[] {Vehicle.Car},
            new Vehicle[] {Vehicle.Car},
            new Vehicle[] {Vehicle.Car},
            new Vehicle[] {Vehicle.Car},
            new Vehicle[] {Vehicle.Car},
            new Vehicle[] {Vehicle.Car}
        };

        private static readonly Vehicle[][] Level2 = {
            new Vehicle[] {Vehicle.Car, Vehicle.Car},
            new Vehicle[] {Vehicle.Car, Vehicle.None, Vehicle.Car},
            new Vehicle[] {Vehicle.Car, Vehicle.Car, Vehicle.Car},
            new Vehicle[] {Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.None, Vehicle.Car},
            new Vehicle[] {Vehicle.Truck},
            new Vehicle[] {Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.None, Vehicle.Car},
            new Vehicle[] {Vehicle.Car, Vehicle.Car, Vehicle.Car},
            new Vehicle[] {Vehicle.Car, Vehicle.None, Vehicle.Car},
            new Vehicle[] {Vehicle.Car, Vehicle.Car},
            new Vehicle[] {Vehicle.Car}
        };

        private static readonly Vehicle[][] Level3 = {
            new Vehicle[] {Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.Car},
            new Vehicle[] {Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.Car},
            new Vehicle[] {Vehicle.Car},
            new Vehicle[] {Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.Car},
            new Vehicle[] {Vehicle.Car},
            new Vehicle[] {Vehicle.Truck},
            new Vehicle[] {Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.Car},
            new Vehicle[] {Vehicle.Car},
            new Vehicle[] {Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.Car},
            new Vehicle[] {Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.Car, Vehicle.None, Vehicle.None, Vehicle.Car}
        };

        private static readonly Vehicle[][] Level4 = {
            new Vehicle[] {Vehicle.Truck},
            new Vehicle[] {Vehicle.Truck},
            new Vehicle[] {Vehicle.Truck},
            new Vehicle[] {Vehicle.Truck},
            new Vehicle[] {Vehicle.Truck},
            new Vehicle[] {Vehicle.Truck},
            new Vehicle[] {Vehicle.Truck},
            new Vehicle[] {Vehicle.Truck},
            new Vehicle[] {Vehicle.Truck},
            new Vehicle[] {Vehicle.Truck}
        };

        public static int Levels = 4;

        public static void SetLevel(int level) {
            Vehicle[][] SelectedLevel = null;
            switch (level) {
                case 0:
                    SelectedLevel = GenerateRandomLevel();
                    break;
                
                case 1:
                    SelectedLevel = Level1;
                    break;
                
                case 2:
                    SelectedLevel = Level2;
                    break;
                
                case 3:
                    SelectedLevel = Level3;
                    break;
                
                case 4:
                    SelectedLevel = Level4;
                    break;
                
                default:
                    SelectedLevel = new Vehicle[0][];
                    break;
            }


            var car1 = Resources.Load<GameObject>("Prefabs/Car1");
            var car2 = Resources.Load<GameObject>("Prefabs/Car2");
            var truck = Resources.Load<GameObject>("Prefabs/Truck");
            
            ScaleAdapter.adaptToHeight(car1, GameConstants.FreeWay.CarHeight);
            ScaleAdapter.adaptToHeight(car2, GameConstants.FreeWay.CarHeight);
            ScaleAdapter.adaptToHeight(truck, GameConstants.FreeWay.CarHeight);

            float car1Size = car1.GetComponent<SpriteRenderer>()
                .sprite.bounds.size.x  * car1.transform.localScale.x;
            
            float truckSize = truck.GetComponent<SpriteRenderer>()
                                 .sprite.bounds.size.x * truck.transform.localScale.x;

            Debug.Log(car1Size);
            for (int i = 0; i < 10; i++) {
                float currentPosition = GameConstants.World.OutsideRightBound;
                
                foreach (var vehicle in SelectedLevel[i]) {

                    Vector3 spawnPosition = new Vector3(
                        currentPosition,
                        GameConstants.FreeWay.LaneHeight * (5 - i) - GameConstants.FreeWay.LaneHeight/2,
                        -1f
                        );

                    GameObject newCar = null;
                    switch (vehicle) {
                        case Vehicle.Car:
                            var car = i % 2 == 0 ? car1 : car2;
                            newCar = Object.Instantiate(car, spawnPosition, Quaternion.identity);
                            currentPosition += car1Size;
                            break;
                        case Vehicle.Truck:
                            newCar = Object.Instantiate(truck, spawnPosition, Quaternion.identity);
                            currentPosition += truckSize;
                            break;
                        case Vehicle.None:
                            break;
                    }

                    if (newCar != null) {
                        var carComponent = newCar.GetComponent<Car>();
                        carComponent.Direction = i < 5 ? CarDirection.Left : CarDirection.Right;
                        carComponent.Lane = i;
                    }

                    currentPosition += car1Size;
                    if (currentPosition > GameConstants.World.OutsideRightBound) {
                        currentPosition -= GameConstants.World.OutsideRightBound;
                        currentPosition = GameConstants.World.OutsideLeftBound + currentPosition;
                    }
                }
                
            }
            
        }

        private static Vehicle[][] GenerateRandomLevel() {
            var randomLevel = new Vehicle[10][];
            for (int i = 0; i < 10; i++) {
                var lane = new Vehicle[8];
                for (int j = 0; j < 8; j++) {
                    lane[j] = GetNextRandomVehicle();
                }
                randomLevel[i] = lane;
            }

            return randomLevel;
        }

        private static Vehicle GetNextRandomVehicle() {
            var rand = Random.value;
            if (rand < 0.8) {
                return Vehicle.None;
            }

            if (rand < 0.95) {
                return Vehicle.Car;
            }

            return Vehicle.Truck;

        }

    }
}
