using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class TornadoScript : MonoBehaviour
{
    private float radius;

    private Vector3 pos;

    [SerializeField]private float speed;

    private bool inbounds;

    private Rigidbody rb;

    [SerializeField]private LayerMask Ground;
    [SerializeField] private float Gradius = 0.4f;
    [SerializeField] private float Radius = 2f;

    [SerializeField] private Vector3 distance;

    public float spread;
    private float xSpread;
    private float zSpread;
    public Transform centerPoint;

    public float rotSpeed;

    private float timer = 0;

    
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       xSpread = spread;
       zSpread = spread;
       centerPoint = GameObject.FindWithTag("Centerpoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    
    
    void Update()
    {
        timer += Time.deltaTime * rotSpeed;
        Rotate();
       transform.LookAt(centerPoint);
    }

    void Rotate()
    {
        float x = -Mathf.Cos(timer) * xSpread;
        float z = Mathf.Sin(timer) * zSpread;
        Vector3 pos = new Vector3(x, 0, z);
        transform.position = pos + centerPoint.position;
        xSpread-= 2;
        zSpread -= 2;

        if (xSpread < 5 & zSpread < 5)
        {
            xSpread = spread;
            zSpread = spread;
        }
    }

    
    //private void FixedUpdate()
    //{
        
        
       // inbounds = Physics.CheckSphere(transform.position - distance, Gradius, Ground); 
            
        
            
       // if (!inbounds)
       // {
        //    rb.velocity = new Vector3(0, 0, 0);
       //     transform.position = new Vector3(10.7f,3.95f,25.4f);
        //}

        //else
       // {
         //   rb.AddForce(UnityEngine.Random.Range(-speed, speed), 0, UnityEngine.Random.Range(-speed, speed), ForceMode.Force);
       // }
    
   // }
}
