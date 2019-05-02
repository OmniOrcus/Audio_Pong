using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempScoreDisplay : MonoBehaviour {

    ScoreManager scoreManager;
    Text scoreDisplay;

    void Awake() {
        scoreManager = GameObject.FindGameObjectWithTag("Master").GetComponent<ScoreManager>();
        scoreDisplay = GetComponent<Text>();
    }

    void FixedUpdate() {
        if (scoreManager.inPlay)
            scoreDisplay.text = (scoreManager.GetScore(0) + " : " + scoreManager.GetScore(1));
    }

}
