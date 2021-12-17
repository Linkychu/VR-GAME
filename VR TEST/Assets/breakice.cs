using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            Destroy(gameObject, 0.0001f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            Destroy(gameObject, 0.0001f);
        }
    }
}
