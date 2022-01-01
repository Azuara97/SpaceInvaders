using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Stats
    int health;
    float cdMovement;
    int scoreInDeath;

    //Movement
    int timesMove;
    bool movingRight = true;
    bool movingLeft = false;

    //Others
    enum levels { level1, level2 }

    void Start()
    {

    }

    void Update()
    {
        
    }

    //SetUp
    void SetUpMovement(int level)
    {
        switch (level)
        {
            case (int)levels.level1:
                cdMovement = 2f;
                break;
            case (int)levels.level2:
                cdMovement = 1f;
                break;
        }
        InvokeRepeating("Move", 1f, cdMovement);
    }
    public void SetupEnemyType1(int level)
    {
        health = 1;
        scoreInDeath = 1;
        SetUpMovement(level);
    }
    public void SetupEnemyType2(int level)
    {
        health = 2;
        scoreInDeath = 2;
        SetUpMovement(level);
    }
    public void SetupEnemyType3(int level)
    {
        health = 3;
        scoreInDeath = 3;
        SetUpMovement(level);
    }

    //Movement
    void Move()
    {
        if (movingRight)
        {
            if (timesMove < 5)
            {
                transform.position += new Vector3(1f, 0f, 0f);
                timesMove++;
            }
            else
            {
                transform.position += new Vector3(0f, -1f, 0f);
                timesMove = 0;
                movingRight = false;
                movingLeft = true;
            }
        }
        else if (movingLeft)
        {
            if (timesMove < 5)
            {
                transform.position += new Vector3(-1f, 0f, 0f);
                timesMove++;
            }
            else
            {
                transform.position += new Vector3(0f, -1f, 0f);
                timesMove = 0;
                movingRight = true;
                movingLeft = false;
            }
        }

        if (transform.position.y < 0)
        {
            MenusManager menus = FindObjectOfType<MenusManager>();
            if (menus)
            {
                menus.FinishGame();
            }
            else { Debug.Log("No encontro MenusManager"); }
        }
    }
    public void UpgradeSpeed(int level)
    {
        CancelInvoke();
        cdMovement = cdMovement / level;
        InvokeRepeating("Move", 0f, cdMovement);
    }

    //Death
    void SendScore()
    {
        MyGameManager gameManager = FindObjectOfType<MyGameManager>();
        if (gameManager)
        {
            if (transform.position.y >= 8)
            {
                gameManager.AddScore(scoreInDeath * 3);
            }
            else
            {
                gameManager.AddScore(scoreInDeath);
            }
        }
        else { Debug.Log("No encontro MyGameManager"); }
    }
    void SpawnBuff()
    {
        int random = Random.Range(0, 2);
        if (random == 1)
        {
            Instantiate(Resources.Load("Prefabs/Enemies/Buff"), transform.position, Quaternion.identity);
        }
    }
    void CheckDeath()
    {
        if (health <= 0)
        {
            SendScore();
            SpawnBuff();
            Destroy(gameObject);
        }
    }

    //Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            Destroy(collision.gameObject);
            health--;
            CheckDeath();
        }
        else if (collision.gameObject.GetComponent<PlayerController>())
        {
            MenusManager menus = FindObjectOfType<MenusManager>();
            if (menus)
            {
                menus.FinishGame();
            }
            else { Debug.Log("No encontro MenusManager"); }
        }
    }
}
