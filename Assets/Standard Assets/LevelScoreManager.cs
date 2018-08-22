using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScoreManager: MonoBehaviour {
    
    
    [SerializeField]
    private Text textScoreP1;
    [SerializeField]
    private Text textScoreP2;

    
    private void Start() {
        ScoreManager.instance.addCallBack(() => {
            textScoreP1.text = ScoreManager.instance.p1Score.ToString();
            textScoreP2.text = ScoreManager.instance.p2score.ToString();
        });
    }
}

