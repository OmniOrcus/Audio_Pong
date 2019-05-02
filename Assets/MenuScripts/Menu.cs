using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject firstMenuItem;

	// Use this for initialization
	void Awake () {
        firstMenuItem.GetComponent<Button>().Select();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void PlayGame() {
        Debug.Log("Starting Game");
        SceneManager.LoadScene(1);
    }

    public void ExitGame() {
        Debug.Log("Exiting");
        Application.Quit();
    }

}
