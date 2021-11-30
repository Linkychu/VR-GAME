using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]

public class WindEffect : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed;
    [SerializeField] private GameObject windExplosionGameObject;
    [SerializeField] private float radius;
    [SerializeField] public float explosionForce;

    public int Damage = 100;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position +=  (transform.forward + new Vector3(0, 0, speed) * Time.deltaTime);
    }


    // Update is called once per frame

    private void OnCollisionEnter(Collision other)
    {
        GameObject instantiate = Instantiate(windExplosionGameObject, transform.position, transform.rotation);
        Destroy(instantiate, 1f);
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
                HitRig.AddExplosionForce(explosionForce, transform.position, radius , Random.Range(explosionForce/4 , explosionForce / 2));
            }
        }
        
    }
}
