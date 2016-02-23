using UnityEngine;
using System.Collections;

public class LivingChecking : MonoBehaviour {

    public bool gameRun = true;
    GameObject MonstersAlive;
    GameObject PlayerAlive;
    public GameObject Pause;
    // Use this for initialization
    void Start () {
        Pause = GameObject.FindGameObjectWithTag("Pause");
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.GetComponent<Pause>().PauseOn == false)
        {
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
}
