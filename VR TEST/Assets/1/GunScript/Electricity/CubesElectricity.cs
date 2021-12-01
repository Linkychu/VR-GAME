using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesElectricity : MonoBehaviour
{
    private Rigidbody rb;
    private Renderer _renderer;
    private Material material;
    Color initialColour;
    private int colurvar;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        material = GetComponent<Material>();

        initialColour = GetComponent<Renderer>().material.color;






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
            _renderer.material.color = Color.yellow;
            StartCoroutine(ShockTimer());
        }
    }

    IEnumerator ShockTimer()
    {
        yield return new WaitForSeconds(10);
        rb.constraints = RigidbodyConstraints.None;
        _renderer.material.color = initialColour;
    }
}
