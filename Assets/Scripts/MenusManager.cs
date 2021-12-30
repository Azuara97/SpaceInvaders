using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusManager : MonoBehaviour
{
    //Panels
    GameObject mainMenuPanel;
    GameObject creditsPanel;
    GameObject gamePanel;
    GameObject pauseGamePanel;
    GameObject gameOverPanel;

    void Start()
    {
        SetupPanels();
    }

    void Update()
    {
        
    }

    //Start
    void SetupPanels()
    {
        mainMenuPanel = transform.GetChild(0).gameObject;
        creditsPanel = transform.GetChild(1).gameObject;
        gamePanel = transform.GetChild(2).gameObject;
        pauseGamePanel = gamePanel.transform.GetChild(2).gameObject;
        gameOverPanel = transform.GetChild(3).gameObject;

        creditsPanel.SetActive(false);
        gamePanel.SetActive(false);
        pauseGamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    //Buttons
    //Main
    public void PlayLevel1()
    {
        gamePanel.SetActive(true);
        pauseGamePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
    }
    public void PlayLevel2()
    {
        gamePanel.SetActive(true);
        pauseGamePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
    }
    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
    //Credits
    public void ReturnMainMenuFromCredits()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    //Game
    public void PauseGame()
    {
        pauseGamePanel.SetActive(true);
    }
    public void ClosePauseGame()
    {
        pauseGamePanel.SetActive(false);
    }
    public void ReturnMainMenuFromGame()
    {
        gamePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void FinishGame()
    {
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
    }
    //GameOver
    public void PlayAgain()
    {
        gamePanel.SetActive(true);
        pauseGamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
    public void ReturnMainMenuFromGameOver()
    {
        mainMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }
}
