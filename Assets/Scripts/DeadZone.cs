using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{

    RoundStarter starter;
    ScoreManager scores;
    GameOverHandler gameOver;
    public uint player;

    void Awake()
    {
        GameObject master = GameObject.FindGameObjectWithTag("Master");
        starter = master.GetComponent<RoundStarter>();
        scores = master.GetComponent<ScoreManager>();
        gameOver = GameObject.Find("GameOver").GetComponent<GameOverHandler>();
    }

    void FixedUpdate() {
        if (!scores.inPlay)
        {
            starter.enabled = false;
            gameOver.GameOver(scores.Winner);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            Destroy(col.gameObject);
            starter.inPlay = false;
            scores.AddPoint(player);
        }
    }

}
