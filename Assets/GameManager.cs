using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static bool areControlsSwapped;

    public GameObject overHeadCamera;

    Vector3 camPOS1, camPOS2;

	// Use this for initialization
	void Start ()
    {
        camPOS1 = new Vector3(-24f, 30, -1.5f);
        camPOS2 = new Vector3(43.5f, 30, -1.5f);

        areControlsSwapped = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            overHeadCamera.transform.position = camPOS1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            overHeadCamera.transform.position = camPOS2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            areControlsSwapped = !areControlsSwapped;
        }
	}
}
