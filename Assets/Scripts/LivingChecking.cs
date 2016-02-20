using UnityEngine;
using System.Collections;

public class LivingChecking : MonoBehaviour {

    public bool gameRun = true;
    GameObject MonstersAlive;
    GameObject PlayerAlive;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        MonstersAlive = GameObject.Find("EnemySpawning");
        PlayerAlive = GameObject.Find("Player");
        if (MonstersAlive.GetComponent<SpawningScript>().MonsterCount > 0 
            && PlayerAlive.GetComponent<PlayerController>().Alive == true)
            gameRun = true;
        else
            gameRun = false;
        if (gameRun == false)
            Application.Quit();
	}
}
