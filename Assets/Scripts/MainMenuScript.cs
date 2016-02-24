using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    public Canvas MainMenu;
    public Button PlayButton;
    public Button ExitButton;

	// Use this for initialization
	void Start () {
        MainMenu = MainMenu.GetComponent<Canvas>();
        PlayButton = PlayButton.GetComponent<Button>();
        ExitButton = ExitButton.GetComponent<Button>();
	}
	
    public void ExitPress()
    {
        Application.Quit();
    }

    public void PlayPress()
    {
        SceneManager.LoadScene(1);
    }
}
