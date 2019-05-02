using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DevControls : MonoBehaviour {

    //Dev UI Links
    GameObject devUI;

    //Components that need controlling
    AIPlayer myAI;
    AIClassic classic;
    Text aiUI;
    AudioListener sound;

	// Use this for initialization
	void Awake () {
        //UI Links
        devUI = GameObject.Find("DevUI");
        aiUI = GameObject.Find("AIDis").GetComponent<Text>();
        //Components
        myAI = GetComponent<AIPlayer>();
        classic = GetComponent<AIClassic>();
        sound = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
    }
	
	// Update is called once per frame
	void Update () {
        ControlChecks();
	}

    void ControlChecks() {
        if (Input.GetKeyDown(KeyCode.U)) { DevUISwitch(); }
        if (Input.GetKeyDown(KeyCode.I)) { SwitchAI(); }
        if (Input.GetKeyDown(KeyCode.M)) { MuteSound(); }
        if (Input.GetKeyDown(KeyCode.R)) { Restart(); }
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) { IncreaseDificulty(); }
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) { DecreaseDificulty(); }
    }

    void SwitchAI()
    {
        aiUI.text = (1 - int.Parse(aiUI.text)).ToString() ;
        myAI.enabled = !myAI.enabled;
        classic.enabled = !classic.enabled;
    }

    void MuteSound()
    {
        sound.enabled = !sound.enabled;
    }

    void Restart() {
        SceneManager.LoadScene(0);
    }

    void DevUISwitch() { devUI.active = !devUI.active; }

    void IncreaseDificulty() {
        if (myAI.thoughtSpeed - 4 > 0)
        {
            myAI.thoughtSpeed -= 4;
            classic.thoughtSpeed++;
        }
    }

    void DecreaseDificulty()
    {
        if (classic.thoughtSpeed - 1 > 0)
        {
            myAI.thoughtSpeed += 4;
            classic.thoughtSpeed--;
        }
    }

}
