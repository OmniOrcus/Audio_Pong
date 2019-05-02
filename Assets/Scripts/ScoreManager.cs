using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public string[] scoreDictionary;
    public uint[] playerScores;
    public uint winValue;

    public bool inPlay = true;
    public uint Winner = 0;

    ScoreAnouncer anouncer;

    void Awake() {
        anouncer = GetComponent<ScoreAnouncer>();
        for(uint i = 0; i < playerScores.Length; i++) {
            playerScores[i] = 0;
        }
    }

    public string GetScore(uint player) {
        return scoreDictionary[playerScores[player]];
    }

    public void AddPoint(uint player) {
        if (inPlay)
        {
            playerScores[player]++;
            DuceHandle(player);
        }
        if (playerScores[player] >= winValue)
        {
            inPlay = false;
            Winner = player;
        }
        AnounceScore();
    }

    public void RemovePoint(uint player)
    {
        playerScores[player]--;
    }

    void DuceHandle(uint player) {
        if (playerScores[player] == winValue - 1)
        {
            if (playerScores[1 - player] == winValue - 1) {
                //Duel Advantage
                playerScores[player]--;
                playerScores[1-player]--;
            } else if(playerScores[1 - player] < winValue - 2)
            {
                //Win by two check;
                playerScores[player]++;
            }
        }
    }

    void AnounceScore() {
        uint matrixIndex = (playerScores[0] * (winValue - 1)) + playerScores[1];
        if (playerScores[0] == 4) { matrixIndex = 16; }
        if (playerScores[1] == 4) { matrixIndex = 17; }
        if (!inPlay) { matrixIndex = 18+Winner; }
        anouncer.PlayScore(matrixIndex);
    }
}
