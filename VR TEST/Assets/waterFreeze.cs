using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterFreeze : MonoBehaviour
{
    private Renderer waterRend;

    public PhysicMaterial water;

    public PhysicMaterial ice;

    public Material iceM;

    public Material waterM;

    private bool frozen;
    private Collider waterCol;
    
    // Start is called before the first frame update
    void Start()
    {
        waterRend = GetComponent<Renderer>();
        water = GetComponent<PhysicMaterial>();
        waterM = waterRend.material;
        waterCol = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ice") && !frozen)
        {
            frozen = true;
            waterRend.material = iceM;
            waterCol.material = ice;
            waterCol.isTrigger = false;

        }
        
        if (other.gameObject.CompareTag("Fire") && frozen)
        {
            frozen = false;
            waterRend.material = waterM;
            waterCol.material = water;
            waterCol.isTrigger = true;
        }
        
        if (other.gameObject.CompareTag("Fire") && !frozen)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ice") && !frozen)
        {
            frozen = true;
            waterRend.material = iceM;
            waterCol.material = ice;
            waterCol.isTrigger = false;

        }


        if (other.gameObject.CompareTag("Fire") && frozen)
        {
            frozen = false;
            waterRend.material = waterM;
            waterCol.material = water;
            waterCol.isTrigger = true;
        }


        if (other.gameObject.CompareTag("Fire") && !frozen)
        {
            Destroy(gameObject);
        }
    }
}
