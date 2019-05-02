using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlace : MonoBehaviour {

    //public float highPitch=2.5f;
    //public float lowPitch=0.5f;
    public float maxYDisplacement = 1;

    public float highVolume = 1;
    public float lowVolume = 0.4f;
    public float maxXDisplacement = 8;

    AudioSource ballDrone;
    RoundStarter ballLink;
    float deltaPitch;
    float basePitch;
    float deltaVolume;
    float baseVolume;

    // Use this for initialization
    void Awake () {
        ballDrone = GetComponent<AudioSource>();
        ballLink = GameObject.FindGameObjectWithTag("Master").GetComponent<RoundStarter>();
        //deltaPitch = (highPitch - lowPitch)/2;
        //basePitch = deltaPitch + lowPitch;
        deltaVolume = (highVolume - lowVolume) / 2;
        baseVolume = deltaVolume + lowVolume;
    }
	
	// Update is called once per frame
	void Update () {
        ballDrone.enabled = ballLink.inPlay;
        if (ballLink.inPlay) {
            ballDrone.panStereo = /*basePitch + (deltaPitch * */((ballLink.getBall().transform.position.y) / maxYDisplacement);
            //Adding Pitch Change que to X Position
            ballDrone.volume = baseVolume + (deltaVolume * ((ballLink.getBall().transform.position.x) / maxXDisplacement));
            //ballDrone.pitch = 1.5f + (-1.0f * ((ballLink.getBall().transform.position.x) / maxXDisplacement));
        }
        
	}
}
