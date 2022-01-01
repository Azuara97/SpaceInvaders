using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    void Start()
    {
        while (transform.position.y > 0)
        {
            transform.position -= new Vector3(0f, 1f, 0f);
        }
        StartCoroutine(DestroyObj());
    }

    void Update()
    {
        
    }

    //Coroutine
    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
