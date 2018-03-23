using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBlocks : MonoBehaviour {

    public bool flip;
    float speed;
    float multiplier;

	// Use this for initialization
	void Start ()
    {
        flip = false;
        speed = 1;
        multiplier = Random.Range(.6f, 4f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (flip)
        {
            gameObject.transform.rotation = Quaternion.SlerpUnclamped(gameObject.transform.rotation, Quaternion.Euler(Vector3.zero), (speed * multiplier) * Time.deltaTime);
        }
	}
}
