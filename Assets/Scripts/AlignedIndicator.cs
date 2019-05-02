using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignedIndicator : MonoBehaviour {

    AudioSource AlignedSound;
    RoundStarter ballLink;
    PlayerControler playerLink;

    public float alignmentBuffer;
    public float falloffBuffer;
    float b2pYDiff;
    float maxVolume;

    // Use this for initialization
    void Awake () {
        AlignedSound = GetComponent<AudioSource>();
        ballLink = GameObject.FindGameObjectWithTag("Master").GetComponent<RoundStarter>();
        playerLink = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        alignmentBuffer *= alignmentBuffer;
        falloffBuffer *= falloffBuffer;
        maxVolume = AlignedSound.volume;
    }
	
	// Update is called once per frame
	void Update () {
        if (ballLink.inPlay)
        {
            b2pYDiff = ballLink.getBall().transform.position.y - playerLink.transform.position.y;
            Debug.Log("B-P Y Difference: " + b2pYDiff + " / Sound State: " + AlignedSound.isPlaying);
            b2pYDiff *= b2pYDiff;
            if (b2pYDiff <= falloffBuffer)
            {
                if (b2pYDiff > alignmentBuffer)
                {
                    AlignedSound.volume = (1 - ((b2pYDiff - alignmentBuffer) / (falloffBuffer - alignmentBuffer))) * maxVolume;
                } else
                {
                    AlignedSound.volume = maxVolume;
                }
                if (!AlignedSound.isPlaying)
                    AlignedSound.Play();
            }
            else if (AlignedSound.isPlaying)
            {
                AlignedSound.Stop();
            }
        }
	}
}
