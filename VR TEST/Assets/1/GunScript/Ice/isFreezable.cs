using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class isFreezable : MonoBehaviour
{
    public GameObject IceBlock;

    private Collider col;

    public bool Frozen = true;

    private GameObject Ice;

    private Rigidbody rb;

    public float iceSeconds = 10;
    public float doubleIceSeconds;
    public float seconds;
    private float fireSeconds = 0.1f;
    public GameObject water;

    private Renderer _renderer;
    
    

    private SystemicProperties _systemicProperties;

    private isFlammable _flammable;

    private Material mat;

    private Renderer rendererinChildren;

    private Color originalcolour;
    
    private Color originalcolourC;

    public bool isWater;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        _systemicProperties = GameObject.FindWithTag("GameManager").GetComponent<SystemicProperties>();
        doubleIceSeconds = iceSeconds * 2;
        seconds = iceSeconds;
        Frozen = false;
        _flammable = GetComponent<isFlammable>();
        _renderer = GetComponent<Renderer>();

        mat = _renderer.material;
        
       rendererinChildren = GetComponentInChildren<Renderer>();
       originalcolour = _renderer.material.color;
       originalcolourC = rendererinChildren.material.color;

    }

    // Update is called once per frame
    void Update()
    {
        if (_systemicProperties.Temperature < -500)
        {
            seconds = doubleIceSeconds;
            
        }

        else
        {
            seconds = iceSeconds;
        }

        if (_systemicProperties.Temperature > 500)
        {
            Frozen = false;
            Destroy(Ice);
            rb.constraints = RigidbodyConstraints.None;
            rb.WakeUp();
            rb.isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            if (!Frozen && _flammable.onFire != true)
            {
              
                
                FreezeObject();
                StartCoroutine(IceTimer());
            }
            
        }
        
        
        
        


            if (other.gameObject.CompareTag("Fire"))
        {
            if (Frozen && _flammable.onFire != true)
            {
                Frozen = false;
                Destroy(Ice);
                rb.constraints = RigidbodyConstraints.None;
                Instantiate(water, transform.position, Quaternion.identity);
                rb.WakeUp();
                rb.isKinematic = false;

                
            }
        }
        
            
    }
    

    void FreezeObject()
    {
   
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.isKinematic = true;
        rb.Sleep();
        
        Ice = Instantiate(IceBlock, transform.position, transform.rotation);
        Collider IceCollider = Ice.GetComponent<Collider>();
        Frozen = true;
        Ice.transform.parent = gameObject.transform;
        Ice.transform.localScale = gameObject.transform.localScale * 2;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            FreezeObject();
            StartCoroutine(IceTimer());
        }
        
        if (other.gameObject.CompareTag("Fire"))
        {
            if (Frozen && _flammable.onFire != true)
            {
                Frozen = false;
                Destroy(Ice);
                rb.constraints = RigidbodyConstraints.None;
                rb.WakeUp();
                rb.isKinematic = false;
            }
        }
        
        
    }

    IEnumerator IceTimer()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(Ice);
        Frozen = false;
        rb.constraints = RigidbodyConstraints.None;
        rb.isKinematic = false;
        _renderer.material.color = originalcolour;
        rendererinChildren.material.color = originalcolourC;
        rb.WakeUp();

    }

    
}
