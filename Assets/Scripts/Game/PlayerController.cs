using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Right"))
        {
            transform.position += new Vector3(0.5f, 0f, 0f);
        }
        else if (Input.GetButtonDown("Left"))
        {
            transform.position -= new Vector3(0.5f, 0f, 0f);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            Instantiate(Resources.Load<GameObject>("Prefabs/Player/BulletSprite"), position, Quaternion.identity);
        }
    }
}
