using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    Transform trans;
    Vector3 movement;
    public float moveSpeed = 1;
    public float angleBoost = 1;
    public float randAngMax = 0.05f;
    public float upperBound;
    public float lowerBound;

    public float reboundIncrease = 1;

    AudioSource bounce;
    public AudioClip blockedAudio;
    public float repBuffer;
    float timePassed = 0;
    public bool blockTrig = false;

    void Awake()
    {
        trans = gameObject.transform;
        bounce = gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        movement = trans.position;
        movement.y += (moveSpeed * (-Input.GetAxis("Horizontal")));
        if ((movement.y + moveSpeed) < upperBound && ((movement.y - moveSpeed) > lowerBound))
        {
            trans.position = movement;
        }
        else if(!blockTrig)
        {
            //Audio cue for blocked movement
            bounce.PlayOneShot(blockedAudio);
            blockTrig = true;
        }

        if (blockTrig) {
            //cooldown on blocked movement audio cue
            timePassed += Time.deltaTime;
            if (timePassed >= blockedAudio.length + repBuffer)
            {
                blockTrig = false;
                timePassed = 0f;
            }
        }

    }

    void OnCollisionExit(Collision col) {
        Debug.Log("Player Block");
        bounce.Play();
        Vector3 oldVelo = col.gameObject.GetComponent<Rigidbody>().velocity;
        float mag = oldVelo.magnitude;
        oldVelo.y += (angleBoost * (-Input.GetAxis("Horizontal"))) + (Mathf.Sin(Mathf.Deg2Rad * randAngMax * Mathf.Sin(Random.Range(-1000f, 1000f))) * mag);
        oldVelo = oldVelo.normalized * mag;
        col.gameObject.GetComponent<Rigidbody>().velocity = oldVelo * reboundIncrease;
    }

}
