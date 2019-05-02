using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLimiter : MonoBehaviour {

    public float xLimit;
    Rigidbody ball;

	// Use this for initialization
	void Awake () {
        ball = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        if (ball.velocity.normalized.x * ball.velocity.normalized.x < xLimit * xLimit  && ball.velocity.x != 0)
        {
            Vector3 velo = ball.velocity;
            float mag = velo.magnitude;
            velo = velo.normalized;
            if (velo.x < 0) { velo.x = -xLimit; }
            else { velo.x = xLimit; }
            //velo.x = (body.velocity.x / (Mathf.Sqrt(body.velocity.x * body.velocity.x))) * xLimit;
            ball.velocity = velo.normalized * mag;
            Debug.Log("New Velo: " + ball.velocity.ToString() + "... what? " + ball.velocity.magnitude + " ~ " + mag);
        }

        if (ball.velocity.magnitude == 0) {
            Debug.LogError("ERR! - Ball has Stopped!");
        }

        if (ball.velocity.x == 0)
        {
            Debug.LogError("ERR! - Ball is axis Locked");
        }

    }
}
