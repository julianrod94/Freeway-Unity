using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{

    private static ScoreManager _instance = null;
    public static ScoreManager instance
    {
        get
        {
            if (_instance == null)
                _instance = new ScoreManager();

            return _instance;
        }
        private set { }
    }

    public enum Player{ Player1, Player2 }

    public int maxScore;
  
    private int _p1Score;
    public int p1Score {
        get{ return _p1Score; }
        set { _p1Score = value; notifyChange(); }
    }
  
    private int _p2Score;
    public int p2score {
        get{ return _p2Score; }
        set { _p2Score = value; notifyChange(); }
    }

    private List<Action> callbacks = new List<Action>();

    public void emptyCallBacks()
    {
        callbacks = new List<Action>();   
    }

    public void addCallBack(Action callBack)
    {
        callbacks.Add(callBack);
    }

    private void notifyChange()
    {
        foreach (var callback in callbacks)
        {
            callback.Invoke();
        }
    }

    public void Score(int player) {
        if (player == 1) {
            p1Score++;
        }
        else {
            p2score++;
        }
    }
}

