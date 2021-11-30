using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class WindEffect : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed;
    [SerializeField] private GameObject windExplosionGameObject;
    [SerializeField] private float radius;
    [SerializeField] public float explosionForce;

    public int Damage = 100;


    private void Update()
    {
        transform.position +=  (transform.forward + new Vector3(0, 0, speed) * Time.deltaTime);
    }


    // Update is called once per frame

    private void OnCollisionEnter(Collision other)
    {
        GameObject instantiate = Instantiate(windExplosionGameObject, transform.position, transform.rotation);
        Destroy(instantiate, 2f);
        WindExplosion();
        Destroy(gameObject);
        
    }

    private void WindExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearby in colliders)
        {
            Rigidbody HitRig = nearby.GetComponent<Rigidbody>();
            if (HitRig != null)
            {
                HitRig.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }
        
    }
}
