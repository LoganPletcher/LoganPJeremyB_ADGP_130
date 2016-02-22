using UnityEngine;
using System.Collections;

public class EnemyInRange : MonoBehaviour {

    public bool PiR = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
            PiR = true;
    }

    void OnTriggerExit()
    {
        PiR = false;
    }
}
