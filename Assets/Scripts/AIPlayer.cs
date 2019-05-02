using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour {

    //The AI Player's Movement values
    Transform selfMotion;
    Vector3 movement;

    //Tunable 
    public float moveSpeed = 1;
    public float angleBoost = 1;
    public float upperBound;
    public float lowerBound;
    public float reboundIncrease = 1;

    //Tracking values for the ball;
    RoundStarter ballLink;
    PlayerControler player;
    public float targetLocation;
    float deltaY;

    //AI Delay Between calculations
    public int thoughtSpeed = 0;
    int thoughts = 0;

    //Bounce Sound
    AudioSource bounce;
    float direction = 0;

    // Use this for initialization
    void Awake () {
        selfMotion = gameObject.transform;
        ballLink = GameObject.FindGameObjectWithTag("Master").GetComponent<RoundStarter>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        bounce = gameObject.GetComponent<AudioSource>();
        deltaY = (upperBound - lowerBound);
    }

    void FixedUpdate() {
        if (ballLink.inPlay)
        {
            if (thoughts >= thoughtSpeed)
            {
                CalculateTargetLocation();
                thoughts = 0;
            }
            else {
                thoughts++;
            }

            

            direction = (targetLocation - selfMotion.position.y);
            if (direction >= moveSpeed || direction <= -moveSpeed)
            {
                direction = (direction / (Mathf.Sqrt(direction * direction)));
                Move(direction);
            }

            
        }
    }

    void Move(float direction) {
        movement = selfMotion.position;
        movement.y += (moveSpeed*direction);
        if ((movement.y + moveSpeed) < upperBound && ((movement.y - moveSpeed) > lowerBound))
        {
            selfMotion.position = movement;
        }
    }

    void CalculateTargetLocation() {
        //Get GameState
        Vector3 velo = ballLink.getBall().GetComponent<Rigidbody>().velocity;
        Vector3 pos = ballLink.getBall().GetComponent<Transform>().position;

        //Prime Calculation
        float contYDisp = ((selfMotion.position.x - pos.x) / velo.x) * velo.y;
        float targetY = (pos.y + contYDisp) % deltaY;

        //Experimental - 
        

        // original => if (((pos.y + contYDisp) / deltaY) % 2 > 1)
        //Working Upper/Lower Invertion Code
        if (((pos.y + contYDisp) / deltaY) % 2 > 1)
        {
            Debug.Log("Roof Bounce");
            targetLocation = (deltaY - targetY);
        }
        else
        {
            Debug.Log("Floor Bounce");
            targetLocation = targetY;
        }

        //Debug.Log("Intercept Y: " + targetLocation);

    }

    void OnCollisionExit(Collision col)
    {
        Debug.Log("AI Block");
        bounce.Play();
        Vector3 oldVelo = col.gameObject.GetComponent<Rigidbody>().velocity;
        float mag = oldVelo.magnitude;
        oldVelo.y += (angleBoost * direction);
        oldVelo = oldVelo.normalized * mag;
        col.gameObject.GetComponent<Rigidbody>().velocity = oldVelo * reboundIncrease;
    }

}
