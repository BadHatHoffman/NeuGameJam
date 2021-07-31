using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManagement : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject mainMenuPanel;

    public void Start()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        AudioManager.Instance.Play("MenuSong");

    }

    //scene management
    public void MainMenuScene()
    {
        //scene 0 will be main menu scene
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        //scene 1 will be game in build settings
        SceneManager.LoadScene(1);
    }

    //panel management
    public void Credits()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void MainMenuPanel()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    //game management
    public void QuitGame()
    {
        Application.Quit();
    }
}
