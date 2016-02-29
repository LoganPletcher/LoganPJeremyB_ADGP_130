using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour {

    public bool PauseOn = false;
    public GameObject LC;
    public Canvas Canvas;
    public Text HP;
    public Text Speed;
    public Text Interact;
    public Text PauseT;
    public GameObject BtGButton;
    public GameObject ExitButton;
    public GameObject MButton;
    public GameObject QuitButton;
    public Text Win;
    public Text Lose;
    public Image DOverlay;

	// Use this for initialization
	void Start () {
        LC = GameObject.FindGameObjectWithTag("LivingCheck");
        HP = HP.GetComponent<Text>();
        Speed = Speed.GetComponent<Text>();
        Interact = Interact.GetComponent<Text>();
        PauseT = PauseT.GetComponent<Text>();
        Canvas = Canvas.GetComponent<Canvas>();
        BtGButton = GameObject.FindGameObjectWithTag("BtGButton");
        ExitButton = GameObject.FindGameObjectWithTag("ExitButton");
        MButton = GameObject.FindGameObjectWithTag("MButton");
        QuitButton = GameObject.FindGameObjectWithTag("QuitButton");
        Win = Win.GetComponent<Text>();
        Lose = Lose.GetComponent<Text>();
        DOverlay = DOverlay.GetComponent<Image>();
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
        if(PauseOn && LC.GetComponent<LivingChecking>().gameRun == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Canvas.enabled = true;
            HP.enabled = false;
            Speed.enabled = false;
            Interact.enabled = false;
            PauseT.enabled = true;
            BtGButton.SetActive(true);
            ExitButton.SetActive(true);
            MButton.SetActive(false);
            QuitButton.SetActive(false);
            Win.enabled = false;
            Lose.enabled = false;
            DOverlay.enabled = false;
        }
        if(!PauseOn && LC.GetComponent<LivingChecking>().gameRun == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Canvas.enabled = true;
            HP.enabled = true;
            Speed.enabled = true;
            PauseT.enabled = false;
            BtGButton.SetActive(false);
            ExitButton.SetActive(false);
            MButton.SetActive(false);
            QuitButton.SetActive(false);
            Win.enabled = false;
            Lose.enabled = false;
            DOverlay.enabled = false;
        }
    }

    public void BtGPress()
    {
        PauseOn = false;
    }

    public void ExitPress()
    {
        Application.Quit();
    }

}
