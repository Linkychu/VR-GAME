using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHealth : MonoBehaviour
{
    public float cubeHealth = 1000;

    private int ElectricDamage = 100;

    private int WindDamage = 100;

    private int HeightDamage = 100;

    private int ImpactDamage = 50;

    private int IceDamage = 100;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cubeHealth < 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }

    public void EnemyDamage(int EnemyDamgedNum)
    {
        cubeHealth -= EnemyDamgedNum;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Electricity"))
        {
            EnemyDamage(ElectricDamage);
        }
        
        if (other.gameObject.CompareTag("Wind"))
        {
            EnemyDamage(WindDamage);
        }
        

        if (other.gameObject.CompareTag("Interactable"))
        {
            EnemyDamage(ImpactDamage);
        }
    }
}
