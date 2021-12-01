using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityEffect : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]float speed = 20;
    private Rigidbody rb;
    [SerializeField] private float radius;
    [SerializeField] public float explosionForce;
    [SerializeField] private GameObject electricityExplosion;
    public bool Player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  (transform.forward + new Vector3(0, 0, speed) * Time.deltaTime);

        Debug.Log("SpherePos: " + transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
     
            Rigidbody objectRb = other.gameObject.GetComponent<Rigidbody>();
           
            GameObject instantiate = Instantiate(electricityExplosion, transform.position, transform.rotation);
            Destroy(instantiate, 1f);
            ElectricityExplosion();
            Destroy(gameObject);
     
    }

    private void ElectricityExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearby in colliders)
        {
            Rigidbody HitRig = nearby.GetComponent<Rigidbody>();
            
            if (HitRig != null)
            {
                HitRig.AddExplosionForce(explosionForce, transform.position, radius);
                Destroy(gameObject, 2f);
            }
        }
    }
}
