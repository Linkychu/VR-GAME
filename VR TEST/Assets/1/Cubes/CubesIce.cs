using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesIce : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    private BoxCollider boxCollider;
    private Transform objectTrans;
    [SerializeField]private CubesIce cubesIce;
    [SerializeField] private CubeHealth cubeHealth;
    [SerializeField] private float dps = 50;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        cubeHealth = GetComponent<CubeHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        objectTrans = other.GetComponent<Transform>();
        if (other.gameObject.CompareTag("Ice"))
            Ice();
        
    }

    void Ice()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        boxCollider.size = new Vector3(objectTrans.localScale.x, objectTrans.localScale.y, objectTrans.localScale.z);
        cubeHealth.IceDamage(dps);
        StartCoroutine(IceWait());

    }

    IEnumerator IceWait()
    {
        yield return new WaitForSeconds(10);
        rb.constraints = RigidbodyConstraints.None;
        boxCollider.size = new Vector3(1, 1, 1);
    }
}
