using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    public int playerHealth = 100;
    public int Armour;
    private int Playerdamage = 10;
    
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

      if (playerHealth < 0)
      {
          SceneManager.LoadScene(1);
      }
    }

    public void DealDamage(int damage)
    {
        playerHealth -= damage;
        gameObject.layer = 12;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DealDamage(Playerdamage);
        }
    }

    IEnumerator Invisibility()
    {
        yield return new WaitForSeconds(4);
        //do some cool effects
        gameObject.layer = 6;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Health"))
        {
            HealDamage(100);
            Destroy(other);
        }
        
    }

    public void HealDamage(int HealAmt)
    {
       playerHealth += HealAmt;
    }
}
