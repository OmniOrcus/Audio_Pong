using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainControls : MonoBehaviour
{

    Renderer rend;

    // Use this for initialization
    void Awake()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            rend.enabled = !rend.enabled;
        }
    }
}
