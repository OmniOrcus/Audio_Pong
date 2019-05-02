using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuceHandler : MonoBehaviour {

    ScoreManager manager;
    string duceFlag;
	// Use this for initialization
	void Awake () {
        manager = GetComponent<ScoreManager>();
        duceFlag = manager.scoreDictionary[manager.scoreDictionary.Length - 1];
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (manager.inPlay)
        {
            if (manager.GetScore(0) == duceFlag && manager.GetScore(1) == duceFlag)
            {
                manager.RemovePoint(0);
                manager.RemovePoint(1);
            }
        }
    }
}
