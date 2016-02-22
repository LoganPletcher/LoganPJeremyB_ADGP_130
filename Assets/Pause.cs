using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public bool PauseOn = false;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) && !PauseOn)
        {
            PauseOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && PauseOn)
        {
            PauseOn = false;
        }
    }
}
