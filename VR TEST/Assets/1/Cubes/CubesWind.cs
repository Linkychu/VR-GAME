using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class CubesWind : MonoBehaviour
{
    private NavMeshAgent objectNavMesh;

    private NavMeshAgent _cubesAI;

    private Rigidbody objectRigidbody;

    private CubeHealth _cubeHealth;

    private bool hasBeenHit = false;
    [SerializeField] private float damage = 500;
    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRadius;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        objectNavMesh = GetComponent<NavMeshAgent>();
        _cubeHealth = GetComponent<CubeHealth>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wind"))
        {
            WindPhysics();
        }

        if (hasBeenHit == true)
        {
            WindPhysics2();
        }
    }

    public void WindPhysics()
    {
        //_cubeHealth.WindDamage(damage);
        objectNavMesh.isStopped = true;
        objectRigidbody.isKinematic = false;
        objectRigidbody.constraints = RigidbodyConstraints.None;

        WindForce();
        

    }

    //IEnumerator Reenabled()

    public void WindPhysics2()
    {
        //yield return new WaitForSeconds(3f); 
        objectNavMesh.isStopped = false;
        objectRigidbody.isKinematic = true;
        hasBeenHit = false;


    }

    public void WindForce()
    {
        objectRigidbody.AddForce(0, explosionForce/16, 0);
        hasBeenHit = true;
    }
}
