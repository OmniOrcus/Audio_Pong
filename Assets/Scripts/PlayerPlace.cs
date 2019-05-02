using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlace : MonoBehaviour {

    //public float highPitch = 2.5f;
    //public float lowPitch = 0.5f;

    AudioSource playerDrone;
    PlayerControler playerLink;
    //float deltaPitch;
    //float basePitch;
    float maxDisplacement;

    // Use this for initialization
    void Awake () {
        playerDrone = GetComponent<AudioSource>();
        playerLink = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        //deltaPitch = (highPitch - lowPitch) / 2;
        //basePitch = deltaPitch + lowPitch;
        maxDisplacement = playerLink.upperBound;
    }
	
	// Update is called once per frame
	void Update () {
        playerDrone.panStereo = /*basePitch + (deltaPitch * */-((playerLink.transform.position.y) / maxDisplacement);
    }
}
