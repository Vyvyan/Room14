using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchForMaze4 : MonoBehaviour {

    public Material upMat, downMat;
    Renderer rend;
    public GameObject wallToMove;

    public float turnSpeed;

    public bool turn;

    public bool isHor;

	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
        rend.material = upMat;
        turn = false;
        isHor = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (turn)
        {
            if (isHor)
            {
                wallToMove.transform.rotation = Quaternion.SlerpUnclamped(wallToMove.transform.rotation, Quaternion.Euler(0, 180, 0), turnSpeed * Time.deltaTime);

                if (wallToMove.transform.eulerAngles.y < 180.5 && wallToMove.transform.eulerAngles.y > 179.5)
                {
                    isHor = false;
                    turn = false;
                }
            }
            else
            {
                wallToMove.transform.rotation = Quaternion.SlerpUnclamped(wallToMove.transform.rotation, Quaternion.Euler(0, 90, 0), turnSpeed * Time.deltaTime);

                if (wallToMove.transform.eulerAngles.y < 90.5 && wallToMove.transform.eulerAngles.y > 89.5)
                {
                    isHor = true;
                    turn = false;
                }
            }
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Rat")
        {
            SwitchStuff();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Rat")
        {
            UnSwitchStuff();
        }
    }

    void SwitchStuff()
    {
        rend.material = downMat;
        turn = true;
    }

    void UnSwitchStuff()
    {
        rend.material = upMat;
    }

    public void ResetSwitch()
    {
        wallToMove.transform.eulerAngles = new Vector3(0, 90, 0);
        turn = false;
        isHor = true;
    }

}
