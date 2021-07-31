using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManagement : MonoBehaviour
{
    GameObject creditsPanel;
    GameObject mainMenuPanel;

    void Start()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    //scene management
    void MainMenuScene()
    {
        //scene 0 will be main menu scene
        SceneManager.LoadScene(0);
    }

    void StartGame()
    {
        //scene 1 will be game in build settings
        SceneManager.LoadScene(1);
    }

    //panel management
    void Credits()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    void MainMenuPanel()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
