using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempGameExit : MonoBehaviour {

    ScoreManager score;

    public float exitDelay;
    float timeElapsed = 0;

    void Awake() {
        score = GetComponent<ScoreManager>();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
        }
        if (!score.inPlay) {
            if (timeElapsed < exitDelay) {
                timeElapsed += Time.deltaTime;
            } else
            {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    SceneManager.LoadScene(0);
                }
            }
        }
	}
}
