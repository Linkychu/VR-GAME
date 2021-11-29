using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private Transform playerPos;

    [SerializeField]private GameObject player;

    private Health playerHealth;

    private Camera playerCam;

    private int DamageDealt = 20;

    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<Health>();
        playerCam = player.GetComponentInChildren<Camera>();
        playerPos = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            playerHealth.DealDamage(DamageDealt);
        }
    }
}
