using UnityEngine;
using System.Collections;

public class SkeletonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3
            (Random.Range(-25.0f, 25.0f), 1, Random.Range(-25.0f - 30, 25.0f - 30));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
