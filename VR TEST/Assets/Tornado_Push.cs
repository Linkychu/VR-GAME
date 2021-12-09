using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado_Push : MonoBehaviour
{
    
    [SerializeField] private float radius;
    [SerializeField] public float explosionForce;
    private EnemyToggle enemy;

    public int Damage = 100;
    private Rigidbody rb;


    private CubesWind cubes;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        WindExplosion();

    }

    private void WindExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearby in colliders)
        {
            Rigidbody HitRig = nearby.GetComponent<Rigidbody>();
            
            if (HitRig != null)
            {
                HitRig.AddExplosionForce(explosionForce, transform.position, radius , UnityEngine.Random.Range(explosionForce/4 , explosionForce / 2));
            }
        }
        
    }
}

