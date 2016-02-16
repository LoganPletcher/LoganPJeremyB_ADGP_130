using UnityEngine;
using System.Collections;

public class SpawningScript : MonoBehaviour {

    public GameObject skeleton;

	// Use this for initialization
	void Start () {
        for(int i = 0; i < 19; i++)
            Instantiate(skeleton);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
