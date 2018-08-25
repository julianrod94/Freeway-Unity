using System;
using System.Collections.Generic;

namespace Standard_Assets {
    public class ScoreManager {

        private static ScoreManager _instance = null;
        public static ScoreManager Instance {
            get { return _instance ?? (_instance = new ScoreManager()); }
            private set { _instance = value; }
        }

        public int MaxScore;
  
        private int _p1Score;
        public int P1Score {
            get{ return _p1Score; }
            set { _p1Score = value; NotifyChange(); }
        }
  
        private int _p2Score;
        public int P2Score {
            get{ return _p2Score; }
            set { _p2Score = value; NotifyChange(); }
        }

        private List<Action> _callbacks = new List<Action>();

        public void EmptyCallBacks() {
            _callbacks = new List<Action>();   
        }

        public void AddCallBack(Action callBack) {
            _callbacks.Add(callBack);
        }

        private void NotifyChange() {
            foreach (var callback in _callbacks) {
                callback.Invoke();
            }
        }

        public void Score(Player player) {
            if (player == Player.Player1) {
                P1Score++;
            } else {
                P2Score++;
            }
        }
    }
}

