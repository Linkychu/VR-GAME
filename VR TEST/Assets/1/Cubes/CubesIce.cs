using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubesIce : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    private BoxCollider boxCollider;
    private Transform objectTrans;
    [SerializeField]private CubesIce cubesIce;
    [SerializeField] private CubeHealth cubeHealth;
    private int dps = 5;
    private NavMeshAgent cubeAI;
    private bool frozen;
    private float seconds;
    private Renderer _renderer;
    private Material material;
    Color initialColour;
    private int colurvar;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        cubeHealth = GetComponent<CubeHealth>();
        cubeAI = GetComponent<NavMeshAgent>();
        _renderer = GetComponent<Renderer>();
        material = GetComponent<Material>();

        initialColour = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (frozen)
        {
            StartCoroutine(DamagePerSecond());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        objectTrans = other.gameObject.GetComponent<Transform>();
        if (other.gameObject.CompareTag("Ice"))
        {
            _renderer.material.color = Color.cyan;
            Ice();
        }
    }

    void Ice()
    {
        cubeAI.isStopped = true;
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        boxCollider.size = new Vector3(objectTrans.localScale.x, objectTrans.localScale.y, objectTrans.localScale.z);
        frozen = true;
        StartCoroutine(IceWait());

    }

    IEnumerator IceWait()
    {
        yield return new WaitForSeconds(10);
        cubeAI.isStopped = false;
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints.None;
        boxCollider.size = new Vector3(1, 1, 1);
        frozen = false;
        _renderer.material.color = initialColour;
    }

    IEnumerator DamagePerSecond()
    {
        yield return new WaitForSecondsRealtime(1);
        cubeHealth.EnemyDamage(dps);
        frozen = false;
        yield return new WaitForSecondsRealtime(1);
        frozen = true;

    }
}
