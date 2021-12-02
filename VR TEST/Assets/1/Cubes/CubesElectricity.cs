using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubesElectricity : MonoBehaviour
{
    private Rigidbody rb;
    private Renderer _renderer;
    private Material material;
    Color initialColour;
    private int colurvar;

    [SerializeField] private float damage = 100;
    // Start is called before the first frame update

    private NavMeshAgent cubeAI;
    private CubeHealth _cubeHealth;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        material = GetComponent<Material>();

        initialColour = GetComponent<Renderer>().material.color;


        cubeAI = GetComponent<NavMeshAgent>();
        _cubeHealth = GetComponent<CubeHealth>();




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Electricity"))
        {
            cubeAI.isStopped = true;
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            _renderer.material.color = Color.yellow;
            StartCoroutine(ShockTimer());
        }
    }

    IEnumerator ShockTimer()
    {
        yield return new WaitForSeconds(6);
        rb.constraints = RigidbodyConstraints.None;
        rb.isKinematic = true;
        cubeAI.isStopped = false;
        _renderer.material.color = initialColour;
    }
}
