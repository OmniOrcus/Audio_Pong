using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour {

    Text message;

    public string gameOverMessage;
    public string[] playerNames;

	// Use this for initialization
	void Start () {
        message = GetComponent<Text>();
        message.enabled = false;
    }

    public void GameOver(uint player) {
        message.text = gameOverMessage + "\n" + playerNames[player] + " Won";
        message.enabled = true;
    }

}
