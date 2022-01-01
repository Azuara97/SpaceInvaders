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

    void Start()
    {

    }

    void Update()
    {
        
    }

    //SetUp
    public void SetupEnemyType1()
    {
        health = 1;
        cdMovement = 1f;
        scoreInDeath = 1;
        InvokeRepeating("Move", 1f, cdMovement);
    }
    public void SetupEnemyType2()
    {
        health = 2;
        cdMovement = 2f;
        scoreInDeath = 2;
        InvokeRepeating("Move", 1f, cdMovement);
    }
    public void SetupEnemyType3()
    {
        health = 3;
        cdMovement = 3f;
        scoreInDeath = 3;
        InvokeRepeating("Move", 1f, cdMovement);
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
    void CheckDeath()
    {
        if (health <= 0)
        {
            MyGameManager gameManager = FindObjectOfType<MyGameManager>();
            if (gameManager)
            {
                gameManager.AddScore(scoreInDeath);
            }
            else { Debug.Log("No encontro MyGameManager"); }
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
