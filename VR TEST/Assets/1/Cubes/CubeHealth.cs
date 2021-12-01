using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHealth : MonoBehaviour
{
    public float cubeHealth = 1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cubeHealth < 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }

    public void IceDamage(float iceDps)
    {
        cubeHealth -= iceDps;
    }

    public void WindDamage(float windDamage)
    {
        cubeHealth -= windDamage;
    }

    public void ElectricDamage(float electricDamage)
    {
        cubeHealth -= electricDamage;
    }
}
