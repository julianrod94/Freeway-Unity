﻿namespace Standard_Assets.Scripts {
    public enum GameState { Idle, Menu, Playing, Score }
    public enum Difficulty { Easy, Hard }
    public class GameManager {

        public int Level { get; private set; }
        public int Time { get; private set; }
        public Difficulty P1Difficulty = Difficulty.Easy;
        public Difficulty P2Difficulty = Difficulty.Easy;
        
        
        public GameState State = GameState.Idle;
        private static GameManager _instance = null;
        
        private GameManager() {
            Level = 0;
            Time = 60;
        }

        public static GameManager Instance {
            get { return _instance ?? (_instance = new GameManager()); }
            private set { _instance = value; }
        }

        public Difficulty GetDifficulty(Player player) {
            return player == Player.Player1 ? P1Difficulty : P2Difficulty;
        }

        public void AddLevel() {
            Level = (Level + 1) % 5;
            LevelManager.SetLevel(Level);
        }

        public void RemoveLevel() {
            Level = (Level + 4) % 5;
            LevelManager.SetLevel(Level);
        }

        public void AddTime() {
            Time = (Time % 180) + 30;
        }
        
        public void RemoveTime() {
            Time = ((Time+120) % 180) + 30;
        }
        
    }
}
