using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LivingChecking : MonoBehaviour {

    public bool gameRun = true;
    GameObject MonstersAlive;
    GameObject PlayerAlive;
    public GameObject Pause;
    public Canvas WLMenu;
    public Canvas PauseMenu;
    public Button MButton;
    public Button QuitButton;
    public Text Winner;
    public Text Loser;
    public Image DeathOverlay;
    // Use this for initialization
    void Start () {
        Pause = GameObject.FindGameObjectWithTag("Pause");
        WLMenu = WLMenu.GetComponent<Canvas>();
        PauseMenu = PauseMenu.GetComponent<Canvas>();
        MButton = MButton.GetComponent<Button>();
        QuitButton = QuitButton.GetComponent<Button>();
        Winner = Winner.GetComponent<Text>();
        Loser = Loser.GetComponent<Text>();
        DeathOverlay = DeathOverlay.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRun == true)
            WLMenu.enabled = false;
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
            Cursor.visible = true;
            WLMenu.enabled = true;
            PauseMenu.enabled = false;
            if(PlayerAlive.GetComponent<PlayerController>().Alive == true)
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
