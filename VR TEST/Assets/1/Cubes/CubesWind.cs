using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubesWind : MonoBehaviour
{
    private NavMeshAgent objectNavMesh;

    private CubesAI _cubesAI;

    private Rigidbody objectRigidbody;

    private CubeHealth _cubeHealth;

    [SerializeField] private float damage = 500;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        objectNavMesh = GetComponent<NavMeshAgent>();
        _cubesAI = GetComponent<CubesAI>();
        _cubeHealth = GetComponent<CubeHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        _cubeHealth.WindDamage(damage);
    }

    public void WindPhysics()
    {
        
        Debug.Log("Works");
        _cubesAI.enabled = false;
        objectNavMesh.enabled = false;
        objectRigidbody.isKinematic = false;
        StartCoroutine(Reenabled());
           
        
    }

    public IEnumerator Reenabled()

    {
        yield return new WaitForSeconds(3f);
        _cubesAI.enabled = true;
        objectNavMesh.enabled = true;
        objectRigidbody.isKinematic = true;
    }
}
