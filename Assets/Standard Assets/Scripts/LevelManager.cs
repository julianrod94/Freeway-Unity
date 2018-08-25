﻿using UnityEngine;
using UnityEngine.UI;

namespace Standard_Assets {

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
                .sprite.bounds.size.x * car1.transform.localScale.x;
            float truckSize = truck.GetComponent<SpriteRenderer>()
                                 .sprite.bounds.size.x * truck.transform.localScale.x;

            for (int i = 0; i < 10; i++) {
                float currentPosition = GameConstants.World.Width;
                
                foreach (var vehicle in SelectedLevel[i]) {
                    Debug.Log(currentPosition);

                    Vector3 spawnPosition = new Vector3(
                        currentPosition,
                        GameConstants.FreeWay.LaneHeight * (5 - i) - GameConstants.FreeWay.LaneHeight/2,
                        0.3f
                        );

                    GameObject newCar = null;
                    switch (vehicle) {
                        case Vehicle.Car:
                            var car = i % 2 == 0 ? car1 : car2;
                            newCar = Object.Instantiate(car, spawnPosition, Quaternion.identity);
                            currentPosition += car1Size;
                            break;
                        case Vehicle.Truck:
                            Object.Instantiate(truck, spawnPosition, Quaternion.identity);
                            currentPosition += truckSize;
                            break;
                        case Vehicle.None:
                            break;
                    }

                    if (newCar != null) {                        
                        newCar.GetComponent<Car>().Direction = i < 5 ? CarDirection.Left : CarDirection.Right;
                    }

                    currentPosition += car1Size;
                    if (currentPosition > GameConstants.World.OutsideRightBound) {
                        currentPosition %= GameConstants.World.OutsideBoundSize;
                        currentPosition -= GameConstants.World.OutsideRightBound;
                    }
                }
                
            }
            
        }

    }
}