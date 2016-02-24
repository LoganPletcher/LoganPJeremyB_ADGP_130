using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour {

    public bool PauseOn = false;
    public GameObject LC;
    public Canvas HUD;
    public Canvas PCanvas;
    public Button BtGButton;
    public Button ExitButton;
    

	// Use this for initialization
	void Start () {
        LC = GameObject.FindGameObjectWithTag("LivingCheck");
        HUD = HUD.GetComponent<Canvas>();
        PCanvas = PCanvas.GetComponent<Canvas>();
        BtGButton = BtGButton.GetComponent<Button>();
        ExitButton = ExitButton.GetComponent<Button>();
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
            HUD.enabled = false;
            PCanvas.enabled = true;
        }
        if(!PauseOn && LC.GetComponent<LivingChecking>().gameRun == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            HUD.enabled = true;
            PCanvas.enabled = false;
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
