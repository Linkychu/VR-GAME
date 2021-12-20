using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityEffect : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]float speed = 20;
    private Rigidbody rb;
    [SerializeField] private float radius;
    [SerializeField] public float explosionForce;
    [SerializeField] private GameObject electricityExplosion;

    private SystemicProperties _systemicProperties;
    public bool Player;
    private Collider _collider;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _systemicProperties = GameObject.FindWithTag("GameManager").GetComponent<SystemicProperties>();

    }
    


    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
     
        Debug.Log("Collider name: " + other.collider);
            Rigidbody objectRb = other.gameObject.GetComponent<Rigidbody>();
           
            GameObject instantiate = Instantiate(electricityExplosion, transform.position, transform.rotation);
            Destroy(instantiate, 1f);
            ElectricityExplosion();
            Destroy(gameObject);
     
    }

    private void ElectricityExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearby in colliders)
        {
            Rigidbody HitRig = nearby.GetComponent<Rigidbody>();
            
            if (HitRig != null)
            {
                HitRig.AddExplosionForce(explosionForce, transform.position, radius);
                Destroy(gameObject, 2f);
            }
        }
    }
}
