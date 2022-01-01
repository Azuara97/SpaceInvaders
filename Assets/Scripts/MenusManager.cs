using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenusManager : MonoBehaviour
{
    //Panels
    GameObject mainMenuPanel;
    GameObject creditsPanel;
    GameObject gamePanel;
    GameObject pauseGamePanel;
    GameObject gameOverPanel;

    //Text
    Text scoreText;

    //Others
    int actualLevel;
    enum levels { level1, level2 }

    void Start()
    {
        SetupPanels();
        SetupText();
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
    void SetupText()
    {
        scoreText = gameOverPanel.transform.GetChild(1).GetChild(1).GetComponent<Text>();
    }

    //Game
    void SetUpLevel1()
    {
        actualLevel = (int)levels.level1;
        Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"), Vector3.zero, Quaternion.identity);
        MyGameManager gameManager = FindObjectOfType<MyGameManager>();
        if (gameManager)
        {
            gameManager.SpawnEnemiesLevel1();
        }
        else { Debug.Log("No encontro MyGameManager"); }
    }
    void SetUpLevel2()
    {
        actualLevel = (int)levels.level2;
        Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"), Vector3.zero, Quaternion.identity);
        MyGameManager gameManager = FindObjectOfType<MyGameManager>();
        if (gameManager)
        {
            gameManager.SpawnEnemiesLevel2();
        }
        else { Debug.Log("No encontro MyGameManager"); }
    }
    void RestartGame()
    {
        switch (actualLevel)
        {
            case (int)levels.level1:
                SetUpLevel1();
                break;
            case (int)levels.level2:
                SetUpLevel2();
                break;
        }
    }
    void DeleteGameObjects()
    {
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            Destroy(enemy.gameObject);
        }
        Destroy(FindObjectOfType<PlayerController>().gameObject);
    }

    //Buttons
    //Main
    public void PlayLevel1()
    {
        actualLevel = (int)levels.level1;
        gamePanel.SetActive(true);
        pauseGamePanel.SetActive(false);
        mainMenuPanel.SetActive(false);

        SetUpLevel1();
    }
    public void PlayLevel2()
    {
        actualLevel = (int)levels.level2;
        gamePanel.SetActive(true);
        pauseGamePanel.SetActive(false);
        mainMenuPanel.SetActive(false);

        SetUpLevel2();
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
        DeleteGameObjects();
    }
    public void FinishGame()
    {
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
        DeleteGameObjects();
        MyGameManager gameManager = FindObjectOfType<MyGameManager>();
        if (gameManager)
        {
            scoreText.text = gameManager.GetPlayerScore().ToString();
        }
        else { Debug.Log("No encontro MyGameManager"); }
    }
    //GameOver
    public void PlayAgain()
    {
        gamePanel.SetActive(true);
        pauseGamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        RestartGame();
    }
    public void ReturnMainMenuFromGameOver()
    {
        mainMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }
}
