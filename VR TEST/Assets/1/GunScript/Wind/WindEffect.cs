using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Rigidbody))]

public class WindEffect : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed;
    [SerializeField] private GameObject windExplosionGameObject;
    [SerializeField] private float radius;
    [SerializeField] public float explosionForce;
    private EnemyToggle enemy;
    

    public int Damage = 100;
    private Rigidbody rb;


    private CubesWind cubes;
    private SystemicProperties _systemicProperties;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _systemicProperties = GameObject.FindWithTag("GameManager").GetComponent<SystemicProperties>();
    }

    

    // Update is called once per frame

    
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            GameObject instantiate = Instantiate(windExplosionGameObject, transform.position, Quaternion.identity);
            Destroy(instantiate, 1f);
            //CubesWind cubesWind = other.gameObject.GetComponent<CubesWind>();
            //cubesWind.WindPhysics();
            WindExplosion();
            Destroy(gameObject);
        }

    }

    private void WindExplosion()
    {

        if (_systemicProperties.windd == true)
        {
            radius = radius * 2;
            explosionForce = explosionForce * 2;
        }
        
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearby in colliders)
        {
            Rigidbody HitRig = nearby.GetComponent<Rigidbody>();
            
            if (HitRig != null)
            {
                HitRig.AddExplosionForce(explosionForce, transform.position, radius , UnityEngine.Random.Range(explosionForce/4 , explosionForce / 2));
                Destroy(gameObject, 2f);
            }
        }

    }
}
