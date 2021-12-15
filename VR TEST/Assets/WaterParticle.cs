using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WaterParticle : MonoBehaviour
{
    public ParticleSystem waterPart;
    // Start is called before the first frame update
    void Start()
    {
        waterPart = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Fire"))
        {
            Destroy(other.gameObject);
        }
    }
    
}
