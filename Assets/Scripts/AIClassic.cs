using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIClassic : MonoBehaviour
{

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
    void Awake()
    {
        selfMotion = gameObject.transform;
        ballLink = GameObject.FindGameObjectWithTag("Master").GetComponent<RoundStarter>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        bounce = gameObject.GetComponent<AudioSource>();
        deltaY = (upperBound - lowerBound);
    }

    void FixedUpdate()
    {
        if (ballLink.inPlay)
        {
            if (thoughts < thoughtSpeed)
            {
                CalculateTargetLocation();
                thoughts++;
            }
            else
            {
                thoughts = 0;
            }



            direction = (targetLocation - selfMotion.position.y);
            if (direction >= moveSpeed || direction <= -moveSpeed)
            {
                direction = (direction / (Mathf.Sqrt(direction * direction)));
                Move(direction);
            }


        }
    }

    void Move(float direction)
    {
        movement = selfMotion.position;
        movement.y += (moveSpeed * direction);
        if ((movement.y + moveSpeed) < upperBound && ((movement.y - moveSpeed) > lowerBound))
        {
            selfMotion.position = movement;
        }
    }

    void CalculateTargetLocation()
    {
        Vector3 pos = ballLink.getBall().GetComponent<Transform>().position;

        targetLocation = pos.y;

        Debug.Log("Intercept Y: " + targetLocation);

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
