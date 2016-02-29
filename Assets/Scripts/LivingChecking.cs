using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LivingChecking : MonoBehaviour {

    public bool gameRun = true;
    GameObject MonstersAlive;
    GameObject PlayerAlive;
    public GameObject Pause;
    public Canvas CANVAS;
    public Text HP;
    public Text SPEED;
    public Text PauseT;
    public GameObject BtGButton;
    public GameObject ExitButton;
    public GameObject MButton;
    public GameObject QuitButton;
    public Text Winner;
    public Text Loser;
    public Image DeathOverlay;
    // Use this for initialization
    void Start () {
        Pause = GameObject.FindGameObjectWithTag("Pause");
        CANVAS = CANVAS.GetComponent<Canvas>();
        HP = HP.GetComponent<Text>();
        SPEED = SPEED.GetComponent<Text>();
        PauseT = PauseT.GetComponent<Text>();
        BtGButton = GameObject.FindGameObjectWithTag("BtGButton");
        ExitButton = GameObject.FindGameObjectWithTag("ExitButton");
        MButton = GameObject.FindGameObjectWithTag("MButton");
        QuitButton = GameObject.FindGameObjectWithTag("QuitButton");
        Winner = Winner.GetComponent<Text>();
        Loser = Loser.GetComponent<Text>();
        DeathOverlay = DeathOverlay.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRun == true)
            CANVAS.enabled = true;
        if (Pause.GetComponent<Pause>().PauseOn == false)
        {
            MonstersAlive = GameObject.Find("EnemySpawning");
            PlayerAlive = GameObject.Find("Player");
            if (MonstersAlive.GetComponent<SpawningScript>().MonsterCount > 0
                && PlayerAlive.GetComponent<PlayerController>().Alive == true)
            {
                gameRun = true;
            }
            else
            {
                gameRun = false;
                Pause.GetComponent<Pause>().PauseOn = true;
            }
        }
        if(Pause.GetComponent<Pause>().PauseOn == true && gameRun == false)
        {
            Cursor.lockState = CursorLockMode.None;
            HP.enabled = true;
            SPEED.enabled = true;
            Cursor.visible = true;
            CANVAS.enabled = true;
            BtGButton.SetActive(false);
            ExitButton.SetActive(false);
            MButton.SetActive(true);
            QuitButton.SetActive(true);
            if (PlayerAlive.GetComponent<PlayerController>().Alive == true)
            {
                Winner.enabled = true;
                Loser.enabled = false;
                DeathOverlay.enabled = false;
            }
            else
            {
                Winner.enabled = false;
                Loser.enabled = true;
                DeathOverlay.enabled = true;
            }
        }
    }

    public void BTMPress()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitPres()
    {
        Application.Quit();
    }

}
