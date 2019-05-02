using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour {

    AudioSource player;
    public AudioClip[] sounds;

	// Use this for initialization
	void Awake () {
        player = GetComponent<AudioSource>();

	}
	
	public void PlaySound(uint index)
    {
        player.Stop();
        player.PlayOneShot(sounds[index]);
    }



}
