using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.position += new Vector3(0f, 1f, 0f);
        if (transform.position.y > 20)
        {
            Destroy(gameObject);
        }
    }
}
