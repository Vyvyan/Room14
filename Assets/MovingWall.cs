using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour {

    public float speed;
    public bool movesOnX;

    float startPOS;
    public float endPOS;

    public bool isMovingPositive;

    public float timerLimit;
    public float timerCurrent;

	// Use this for initialization
	void Start ()
    {
        timerCurrent = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (movesOnX)
        {
            if (isMovingPositive)
            {
                gameObject.transform.Translate(Vector3.right * (speed * Time.deltaTime));

                timerCurrent += Time.deltaTime;
                if (timerCurrent >= timerLimit)
                {
                    timerCurrent = 0;
                    isMovingPositive = false;
                }
            }
            else
            {
                gameObject.transform.Translate(Vector3.left * (speed * Time.deltaTime));
                timerCurrent += Time.deltaTime;
                if (timerCurrent >= timerLimit)
                {
                    timerCurrent = 0;
                    isMovingPositive = true;
                }
            }
        
        }
	}
}
