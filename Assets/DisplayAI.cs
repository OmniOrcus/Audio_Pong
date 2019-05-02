using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayAI : MonoBehaviour
{

    //The AI Player's Movement values
    Transform selfMotion;
    Vector3 movement;

    //Tunable 
    public float moveSpeed = 1;
    public float angleBoost = 1;
    public float upperBound;
    public float lowerBound;

    //Tracking values for the ball;
    DisplayBallSpawner ballLink;
    public float targetLocation;
    float deltaY;

    //Bounce Sound
    AudioSource bounce;
    public AudioClip[] bounceSounds;
    uint soundTrack = 0;

    float direction = 0;

    // Use this for initialization
    void Awake()
    {
        selfMotion = gameObject.transform;
        ballLink = GameObject.FindGameObjectWithTag("Master").GetComponent<DisplayBallSpawner>();
        bounce = gameObject.GetComponent<AudioSource>();
        deltaY = (upperBound - lowerBound);
    }

    void FixedUpdate()
    {
        CalculateTargetLocation();
        direction = (targetLocation - selfMotion.position.y);
        if (direction >= moveSpeed || direction <= -moveSpeed)
        {
            direction = (direction / (Mathf.Sqrt(direction * direction)));
            Move(direction);
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
        targetLocation = ballLink.targetY;
    }

    void OnCollisionExit(Collision col)
    {
        bounce.PlayOneShot(bounceSounds[soundTrack++]);
        if (soundTrack >= bounceSounds.Length) {
            soundTrack = 0;
        }
    }
}

