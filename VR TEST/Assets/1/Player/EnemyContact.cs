using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContact : MonoBehaviour

{
    [SerializeField] private int Damage;

    private bool CanBeHit;
    // Start is called before the first frame update
    void Start()
    {
        CanBeHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
       
        if(collision.gameObject.CompareTag("Player"))
        {
            if (CanBeHit)
            {
                GameObject player = collision.gameObject;
                Health playerHealth = collision.gameObject.GetComponent<Health>();
                playerHealth.DealDamage(Damage);
                player.layer = 12;
                CanBeHit = false;  
            }

              
        }
    }
}
