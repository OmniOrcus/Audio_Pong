using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBounce : MonoBehaviour {

    AudioSource bounce;
    public float bounceMultiplier = 1;

    // Use this for initialization
    void Awake () {
        bounce = gameObject.GetComponent<AudioSource>();
	}


        void OnCollisionExit(Collision col)
    {
        Debug.Log("Wall Bounce");
        bounce.Play();
        Vector3 copy = col.rigidbody.velocity;
        copy.y *= bounceMultiplier;
        col.rigidbody.velocity = copy;

    }
}
