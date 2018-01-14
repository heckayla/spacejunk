using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject credits;
    public Button playButton;
    public Button menuButton;

    private void Start()
    {
        
    }

    public void LoadGarbageLevel()
    {
        SceneManager.LoadScene("Junk_Collect");
    }

    public void LoadCredits()
    {
        EventSystem.current.SetSelectedGameObject(null);
        mainMenu.SetActive(false);
        credits.SetActive(true);
        playButton.Select();
        EventSystem.current.SetSelectedGameObject(menuButton.gameObject);
    }

    public void LoadMainMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        mainMenu.SetActive(true);
        credits.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playButton.gameObject);

    }
}
