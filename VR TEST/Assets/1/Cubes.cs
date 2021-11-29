using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cubes : MonoBehaviour
{
    private Rigidbody rb;
    private Renderer _renderer;

   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
