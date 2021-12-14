using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHealth : MonoBehaviour
{
    public float cubeHealth = 1000;

    private int ElectricDamage = 50;

    private int WindDamage = 50;

    private int HeightDamage = 100;

    private int ImpactDamage = 50;

    private int IceDamage = 50;

    private SystemicProperties _systemicProperties;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _systemicProperties = GameObject.FindWithTag("GameManager").GetComponent<SystemicProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cubeHealth < 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }

    public void EnemyDamage(float EnemyDamgedNum)
    {
        cubeHealth -= EnemyDamgedNum;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Electricity"))
        {
            if (_systemicProperties.thunder == true)
            {
                EnemyDamage(ElectricDamage * 2);
            }

            if (_systemicProperties.sun == true)
            {
                EnemyDamage(ElectricDamage / 2);
            }

            else
            {
                EnemyDamage(ElectricDamage);
            }
        }


        if (other.gameObject.CompareTag("Interactable"))
        {
            EnemyDamage(ImpactDamage);
        }

        if (other.gameObject.CompareTag("Ice"))
        {
            if (_systemicProperties.snow == true)
            {
                EnemyDamage(IceDamage * 2);
            }

            else
            {
                EnemyDamage(IceDamage);
            }

            if (_systemicProperties.sun == true)
            {
                EnemyDamage(IceDamage / 4);
            }
            
            
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wind"))
        {
            
            if (_systemicProperties.windd == true)
            {
                EnemyDamage(WindDamage * 2);
            }
            else
            {
                EnemyDamage(WindDamage);
            }

            if (_systemicProperties.sun == true)
            {
                EnemyDamage(WindDamage / 1.5f);
            }
            
        }
    }
}
