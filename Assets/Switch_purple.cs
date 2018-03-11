using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_purple : MonoBehaviour {

    public Material upMat, downMat;
    Renderer rend;
    public GameObject wallToMove, wallToMove2;
    Vector3 startingPOS, startingPOS2;

    public float turnSpeed;

    bool turn;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = upMat;
        turn = false;
        startingPOS = wallToMove.transform.position;
        startingPOS2 = wallToMove2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (turn)
        {
            if (wallToMove.transform.position.y > -5f)
            {
                wallToMove.transform.Translate(Vector3.down * (turnSpeed * Time.deltaTime));
            }
            if (wallToMove2.transform.position.y > -5f)
            {
                wallToMove2.transform.Translate(Vector3.down * (turnSpeed * Time.deltaTime));
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
        wallToMove.transform.position = startingPOS;
        wallToMove2.transform.position = startingPOS2;
        turn = false;
    }
}
