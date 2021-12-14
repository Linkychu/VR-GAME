using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Lightningimpact : MonoBehaviour
{
    private Rigidbody lightningRb;

    [SerializeField] private float speed = 10;

    [SerializeField] private float radius = 20;

    [SerializeField] private float explosionForce = 150;
    // Start is called before the first frame update

    public GameObject fireObject;
    public GameObject ExplosionGameObject;
    void Start()
    {
        lightningRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        lightningRb.AddForce(0, speed, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject instantiate = Instantiate(ExplosionGameObject, transform.position, Quaternion.identity);
        GameObject Fire = Instantiate(fireObject, transform.position, Quaternion.identity);
        Destroy(instantiate, 1f);
        Destroy(gameObject);
        Shock();

    }

    public void Shock()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearby in colliders)
        {
            Rigidbody HitRig = nearby.GetComponent<Rigidbody>();
            
            if (HitRig != null)
            {
                HitRig.AddExplosionForce(explosionForce, transform.position, radius, explosionForce);
                var objectPhysics = HitRig.GetComponent<ObjectPhysics>();
                objectPhysics.Electricity();
                Destroy(gameObject, 2f);
            }
        }
    }
}
