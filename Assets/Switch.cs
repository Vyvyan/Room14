using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public Material upMat, downMat;
    Renderer rend;
    public GameObject wallToMove;

    public float turnSpeed;

    bool turn;

	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
        rend.material = upMat;
        turn = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (turn)
        {
            wallToMove.transform.rotation = Quaternion.SlerpUnclamped(wallToMove.transform.rotation, Quaternion.Euler(0, 180, 0), turnSpeed * Time.deltaTime);
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
    }
}
