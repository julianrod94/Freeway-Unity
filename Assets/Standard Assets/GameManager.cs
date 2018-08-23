namespace Standard_Assets
{
    public class GameManager {
        private enum GameState { Idle, Menu, Playing, Score }
        private static ScoreManager _instance = null;
        
        public static ScoreManager Instance {
            get {
                if (_instance == null)
                    _instance = new ScoreManager();

                return _instance;
            }
            private set { _instance = value; }
        }
    }
}
