using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ObjectPhysics : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider boxCollider;
    private Transform objectTrans;
    [SerializeField] private CubeHealth cubeHealth;
    private float dps = 0.5f;
    private bool frozen;
    private float seconds;
    private Renderer _renderer;
    private Material material;
    Color initialColour;
    private int colurvar;
    private isFlammable _flammable;

    private int firedps = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        cubeHealth = GetComponent<CubeHealth>();
        _renderer = GetComponent<Renderer>();
        material = GetComponent<Material>();

        initialColour = GetComponent<Renderer>().material.color;
        _flammable = GetComponent<isFlammable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (frozen)
        {
            StartCoroutine(DamagePerSecond());
        }

        if (_flammable.onFire == true)
        {
            _renderer.material.color = Color.red;
            cubeHealth.EnemyDamage(firedps);
            StartCoroutine(ResetColour());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            objectTrans = other.gameObject.GetComponent<Transform>();
            if (other.gameObject.CompareTag("Ice"))
            {
                rb.velocity = new Vector3(0, 0, 0);
                _renderer.material.color = Color.cyan;
                Ice();
            }
        }

        if (other.gameObject.CompareTag("Electricity"))
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.constraints = RigidbodyConstraints.FreezeAll;
            _renderer.material.color = Color.yellow;
            StartCoroutine(ShockTimer());
        }
        
    }

    IEnumerator ShockTimer()
    {
        yield return new WaitForSeconds(6);
        rb.constraints = RigidbodyConstraints.None;
        _renderer.material.color = initialColour;
    }
    

    void Ice()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        boxCollider.size = new Vector3(objectTrans.localScale.x, objectTrans.localScale.y, objectTrans.localScale.z);
        frozen = true;
        StartCoroutine(IceWait());

    }

    IEnumerator IceWait()
    {
        yield return new WaitForSeconds(10);
        rb.constraints = RigidbodyConstraints.None;
        boxCollider.size = new Vector3(1, 1, 1);
        frozen = false;
        _renderer.material.color = initialColour;
    }

    IEnumerator DamagePerSecond()
    {
        yield return new WaitForSecondsRealtime(1);
        cubeHealth.EnemyDamage(dps);
        frozen = false;
        yield return new WaitForSecondsRealtime(1);
        frozen = true;

    }

    IEnumerator ResetColour()
    {
        yield return new WaitUntil(() => _flammable.onFire == false);
        _renderer.material.color = initialColour;
    }
}

