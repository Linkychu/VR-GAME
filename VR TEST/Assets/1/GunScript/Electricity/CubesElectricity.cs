using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesElectricity : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Electricity"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine(ShockTimer());
        }
    }

    IEnumerator ShockTimer()
    {
        yield return new WaitForSeconds(10);
        rb.constraints = RigidbodyConstraints.None;
    }
}
