namespace Standard_Assets.Scripts {
    public enum GameState { Idle, Menu, Playing, Score }
    public enum Difficulty { Easy, Hard }
    public class GameManager {
        public bool IsMobile = false;

        public int Level { get; private set; }
        public float Time;
        public Difficulty P1Difficulty = Difficulty.Easy;
        public Difficulty P2Difficulty = Difficulty.Easy;
        
        public GameState State = GameState.Idle;
        private static GameManager _instance = null;
        
        private GameManager() {
            Level = 0;
            Time = 60;
            
            #if UNITY_ANDROID	
				IsMobile = true;
			#endif
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


        public void AdvanceTime(float deltaTime) {
            Time -= deltaTime;
            if (Time < 0) {
                Time = 0;
                State = GameState.Score;
            } 
        }
        
    }
}
