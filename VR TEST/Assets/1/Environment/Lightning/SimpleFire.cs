using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFire : MonoBehaviour
{
    // Start is called before the first frame update

    private SystemicProperties _systemicProperties;
    private int seconds = 5;
    void Start()
    {
        Destroy(gameObject, seconds);
        _systemicProperties = GameObject.FindWithTag("GameManager").GetComponent<SystemicProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_systemicProperties.snow == true)
        {
            seconds = seconds / 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wind"))
        {
            seconds = seconds * 2;
        }
        
        if (other.gameObject.CompareTag("Fire"))
        {
            seconds = seconds * 2;
        }
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wind"))
        {
            seconds = seconds * 2;
        }
        
        if (other.gameObject.CompareTag("Fire"))
        {
            seconds = seconds * 2;
        }

        if (other.gameObject.CompareTag("Water"))
        {
           seconds = seconds / 4; 
        }
    }
    
    
    
}
