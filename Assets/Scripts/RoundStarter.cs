using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStarter : MonoBehaviour
{

    public Vector3 startDirection;
    public float force;
    public GameObject ball;

    public float ballUpperBound;
    public float ballLowerBound;

    GameObject currentBall;
    public bool inPlay = false;

    public float startDelay;
    float delay = 0;

    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay) {
            if (Input.GetAxis("Horizontal") != 0 && delay >= startDelay)
            {
                delay = 0;
                SpawnBall();
            }
            else if (delay < startDelay) {
                delay += Time.deltaTime;
            }
        }
        if (inPlay)
        {
            if (currentBall.transform.position.y > ballUpperBound || currentBall.transform.position.y < ballLowerBound)
            {
                EscapedBall();
            }
        }
    }

    void SpawnBall() {
        inPlay = true;
        currentBall = Instantiate(ball);
        currentBall.GetComponent<Rigidbody>().AddForce(force * startDirection);
    }

    void EscapedBall() {

        Vector3 ballVelo = currentBall.GetComponent<Rigidbody>().velocity;

        //reposition ball
        if (currentBall.transform.position.y > ballUpperBound) {
            
            currentBall.transform.position = new Vector3(currentBall.transform.position.x - (((currentBall.transform.position.y - ballUpperBound) / ballVelo.y) * ballVelo.x), ballUpperBound, 0);
        }
        else if (currentBall.transform.position.y < ballLowerBound) {
            currentBall.transform.position = new Vector3(currentBall.transform.position.x - (((currentBall.transform.position.y - ballLowerBound) / ballVelo.y) * ballVelo.x), ballLowerBound, 0);
        }
        else { currentBall.transform.position = Vector3.zero; }

        //Manually bounce ball and reduce velocity
        ballVelo.y = -ballVelo.y;
        currentBall.GetComponent<Rigidbody>().velocity = ballVelo / 2;
    }

    public GameObject getBall() {
        return currentBall;
    }

}
