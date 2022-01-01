using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Buffs
    bool tripleAttack;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Right"))
        {
            transform.position += new Vector3(1f, 0f, 0f);
        }
        else if (Input.GetButtonDown("Left"))
        {
            transform.position -= new Vector3(1f, 0f, 0f);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (tripleAttack)
            {
                Vector3 position1 = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                Vector3 position2 = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.5f, transform.position.z);
                Vector3 position3 = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z);
                Instantiate(Resources.Load<GameObject>("Prefabs/Player/BulletSprite"), position1, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("Prefabs/Player/BulletSprite"), position2, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("Prefabs/Player/BulletSprite"), position3, Quaternion.identity);
            }
            else
            {
                Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                Instantiate(Resources.Load<GameObject>("Prefabs/Player/BulletSprite"), position, Quaternion.identity);
            }
        }
    }

    //Coroutine
    IEnumerator tripleAttackActive()
    {
        tripleAttack = true;
        yield return new WaitForSeconds(3f);
        tripleAttack = false;
    }

    //Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Buff>())
        {
            if (!tripleAttack)
            {
                StartCoroutine(tripleAttackActive());
            }
            Destroy(collision.gameObject);
        }
    }
}
