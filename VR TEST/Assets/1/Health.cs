using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    public int playerHealth = 100;
    public int Armour;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(gameObject.layer == 12)
        {
            StartCoroutine(Invisibility());
        }
    }

    public void DealDamage(int damage)
    {
        playerHealth -= damage;
    }

    IEnumerator Invisibility()
    {
        yield return new WaitForSeconds(4);
        //do some cool effects
        gameObject.layer = 6;
    }

    
}
