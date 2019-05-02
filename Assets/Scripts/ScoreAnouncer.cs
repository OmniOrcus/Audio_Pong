using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAnouncer : MonoBehaviour {

    public AudioClip[] audioFiles;
    AudioSource speaker;

	// Use this for initialization
	void Awake () {
        speaker = GetComponent<AudioSource>();
	}

    public void PlayScore(uint id) {
        if (id < audioFiles.Length)
            speaker.PlayOneShot(audioFiles[id]);
        else
            Debug.LogError("No Audio file at index " + id);
    }


}
