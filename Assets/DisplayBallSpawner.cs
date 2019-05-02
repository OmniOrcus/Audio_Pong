using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBallSpawner : MonoBehaviour {

    public GameObject ball;
    GameObject currentBall;

    public float upperY;
    public float lowerY;
    public float spawnX;
    public float targetX;
    public float force;

    float deltaY;
    public float targetY;

    // Use this for initialization
    void Awake () {
        deltaY = upperY - lowerY;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentBall != null)
        {
            if (currentBall.transform.position.x > spawnX)
            {
                Destroy(currentBall);
                SpawnBall();
            }
        }
        else {
            SpawnBall();
        }
	}

    void SpawnBall() {

        targetY = (deltaY * Random.value) + lowerY;
        Vector3 origin = (new Vector3(spawnX, (deltaY * Random.value) + lowerY, 0));
        Vector3 target = (new Vector3(targetX, targetY, 0));
        currentBall = Instantiate(ball, origin, Quaternion.identity);
        currentBall.GetComponent<Rigidbody>().AddForce(force * ((target - origin).normalized));
    }

}
