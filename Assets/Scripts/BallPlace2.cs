using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlace2 : MonoBehaviour
{

    public AudioClip upSound;
    public AudioClip flatSound;
    public AudioClip downSound;
    public float flatMargin = 0;

    //public float highPitch=2.5f;
    //public float lowPitch=0.5f;
    public float maxYDisplacement = 1;

    public float highVolume = 1;
    public float lowVolume = 0.4f;
    public float maxXDisplacement = 8;

    AudioSource ballSound;
    RoundStarter ballLink;
    PlayerControler playerLink;



    float deltaPitch;
    float basePitch;
    float deltaVolume;
    float baseVolume;



    // Use this for initialization
    void Awake()
    {

        flatMargin *= flatMargin;

        ballSound = GetComponent<AudioSource>();
        ballLink = GameObject.FindGameObjectWithTag("Master").GetComponent<RoundStarter>();
        playerLink = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();


        //deltaPitch = (highPitch - lowPitch)/2;
        //basePitch = deltaPitch + lowPitch;
        deltaVolume = (highVolume - lowVolume) / 2;
        baseVolume = deltaVolume + lowVolume;
    }

    // Update is called once per frame
    void Update()
    {
        ballSound.enabled = ballLink.inPlay;
        if (ballLink.inPlay)
        {
            
            
            ballSound.panStereo = (playerLink.transform.position.y - ballLink.getBall().transform.position.y) / maxYDisplacement;

            //Adding Pitch Change que to X Position
            ballSound.volume = baseVolume + (deltaVolume * (-(ballLink.getBall().transform.position.x) / maxXDisplacement));
            //ballDrone.pitch = 1.5f + (-1.0f * ((ballLink.getBall().transform.position.x) / maxXDisplacement));

            if (!ballSound.isPlaying)
            {
                SetSound();
            }

        }
    }

    void SetSound() {
        float veloY = ballLink.getBall().GetComponent<Rigidbody>().velocity.y;
        if (veloY * veloY < flatMargin)
        {
            ballSound.PlayOneShot(flatSound);
        }
        else {
            if (veloY > 0) {
                ballSound.PlayOneShot(upSound);
            }
            else
            {
                ballSound.PlayOneShot(downSound);
            }
        }
    }

}
