﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    //Game
    int numberEnemiesInRow = 11;
    int totalEnemiesInLevel;
    int halfEnemiesInLevel;
    int quarterEnemiesInLevel;
    bool speedUpgradedLevel2;
    bool speedUpgradedLevel3;

    //Score
    int playerScore;

    //Others
    enum levels { level1, level2 }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //SetUpGame
    void SpawnEnemiesType1(float x, float y, int level)
    {
        for(float i = x; i < numberEnemiesInRow; i++)
        {
            Vector3 position = new Vector3(i, y, 0f);
            var enemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/EnemyType1"), position, Quaternion.identity);
            enemy.GetComponent<Enemy>().SetupEnemyType1(level);
            totalEnemiesInLevel++;
        }
    }
    void SpawnEnemiesType2(float x, float y, int level)
    {
        for(float i = x; i < numberEnemiesInRow; i++)
        {
            Vector3 position = new Vector3(i, y, 0f);
            var enemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/EnemyType2"), position, Quaternion.identity);
            enemy.GetComponent<Enemy>().SetupEnemyType2(level);
            totalEnemiesInLevel++;
        }
    }
    void SpawnEnemiesType3(float x, float y, int level)
    {
        for (float i = x; i < numberEnemiesInRow; i++)
        {
            Vector3 position = new Vector3(i, y, 0f);
            var enemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/EnemyType3"), position, Quaternion.identity);
            enemy.GetComponent<Enemy>().SetupEnemyType3(level);
            totalEnemiesInLevel++;
        }
    }
    public void SpawnEnemiesLevel1()
    {
        totalEnemiesInLevel = 0;
        playerScore = 0;
        speedUpgradedLevel2 = false;
        speedUpgradedLevel3 = false;
        SpawnEnemiesType3(0f, 15f, (int)levels.level1);
        SpawnEnemiesType2(0f, 14f, (int)levels.level1);
        SpawnEnemiesType2(0f, 13f, (int)levels.level1);
        SpawnEnemiesType1(0f, 12f, (int)levels.level1);
        SpawnEnemiesType1(0f, 11f, (int)levels.level1);
        halfEnemiesInLevel = totalEnemiesInLevel / 2;
        quarterEnemiesInLevel = totalEnemiesInLevel / 4;
    }
    public void SpawnEnemiesLevel2()
    {
        totalEnemiesInLevel = 0;
        playerScore = 0;
        speedUpgradedLevel2 = false;
        speedUpgradedLevel3 = false;
        SpawnEnemiesType3(0f, 15f, (int)levels.level2);
        SpawnEnemiesType2(0.5f, 14f, (int)levels.level2);
        SpawnEnemiesType2(0f, 13f, (int)levels.level2);
        SpawnEnemiesType1(0.5f, 12f, (int)levels.level2);
        SpawnEnemiesType1(0f, 11f, (int)levels.level2);
        halfEnemiesInLevel = totalEnemiesInLevel / 2;
        quarterEnemiesInLevel = totalEnemiesInLevel / 4;
    }

    //Game
    void CheckNumberEnemiesLeft()
    {
        totalEnemiesInLevel--;

        if (totalEnemiesInLevel <= halfEnemiesInLevel && totalEnemiesInLevel >= quarterEnemiesInLevel && !speedUpgradedLevel2)
        {
            foreach(var enemy in FindObjectsOfType<Enemy>())
            {
                enemy.UpgradeSpeed(2);
            }
            speedUpgradedLevel2 = true;
        }
        else if (totalEnemiesInLevel <= quarterEnemiesInLevel && totalEnemiesInLevel > 0 && !speedUpgradedLevel3)
        {
            foreach (var enemy in FindObjectsOfType<Enemy>())
            {
                enemy.UpgradeSpeed(3);
            }
            speedUpgradedLevel3 = true;
        }
        else if (totalEnemiesInLevel <= 0)
        {
            MenusManager menus = FindObjectOfType<MenusManager>();
            if (menus)
            {
                menus.FinishGame();
            }
            else { Debug.Log("No encontro MenusManager"); }
        }
    }
    //Score
    public void AddScore(int score)
    {
        playerScore += score;
        CheckNumberEnemiesLeft();
    }
    public int GetPlayerScore()
    {
        return playerScore;
    }
}
