using UnityEngine;
using System.Collections;

public class SpawningScript : MonoBehaviour {

    public GameObject Monster;
    public int MonsterCount = 1;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 49; i++)
        {
            Instantiate(Monster);
            MonsterCount++;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
