using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupMultiMon : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();

        SceneManager.LoadScene(1);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
