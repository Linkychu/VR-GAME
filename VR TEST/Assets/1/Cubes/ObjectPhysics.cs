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

    private SystemicProperties _systemicProperties;
    private isFreezable _freezable;


    private float electricityTimer;
    private float electricityTimerN = 6;

    private float electricityTimerD;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        cubeHealth = GetComponent<CubeHealth>();
        _renderer = GetComponent<Renderer>();
        material = GetComponent<Material>();

        initialColour = GetComponent<Renderer>().material.color;
        _flammable = GetComponent<isFlammable>();
        _freezable = GetComponent<isFreezable>();
        _systemicProperties = GameObject.FindWithTag("GameManager").GetComponent<SystemicProperties>();

        electricityTimer = electricityTimerN;
        electricityTimerD = electricityTimerN * 2;

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
            _renderer.material.color = initialColour;
            frozen = false;
            _renderer.material.color = Color.red;
            cubeHealth.EnemyDamage(firedps);
            
            StartCoroutine(ResetFireColour());
        }

        if (gameObject.transform.position.y < -50)
        {
            Destroy(gameObject);
        }

        if (_freezable.Frozen)
        {
            _renderer.material.color = initialColour;
            Ice();
            cubeHealth.EnemyDamage(dps);
            
            
        }


        if (_systemicProperties.lightning == true)
        {
            electricityTimer = electricityTimerD;
        }

        else
        {
            electricityTimer = electricityTimerN;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
       

        if (other.gameObject.CompareTag("Electricity"))
        {
            Electricity();
        }
        
    }

    IEnumerator ShockTimer()
    {
        yield return new WaitForSeconds(electricityTimer);
        rb.constraints = RigidbodyConstraints.None;
        rb.WakeUp();
        rb.isKinematic = false;
        _renderer.material.color = initialColour;
        
    }
    

    void Ice()
    {
        
        rb.velocity = new Vector3(0, 0, 0);
        _renderer.material.color = Color.cyan;
        frozen = true;

        StartCoroutine(ResetIceColour());

    }
    

    IEnumerator DamagePerSecond()
    {
        yield return new WaitForSecondsRealtime(1);
        cubeHealth.EnemyDamage(dps);
        frozen = false;
        yield return new WaitForSecondsRealtime(1);
        frozen = true;

    }

    IEnumerator ResetFireColour()
    {
        yield return new WaitUntil(() => _flammable.onFire == false);
        _renderer.material.color = initialColour;
    }

    IEnumerator ResetIceColour()
    {
        yield return new WaitUntil(() => _freezable.Frozen == false);
        _renderer.material.color = initialColour;
        frozen = false;
    }
    

    public void Electricity()
    {
        rb.velocity = new Vector3(0, 0, 0);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.Sleep();
        _renderer.material.color = Color.yellow;
        rb.isKinematic = true;
        StartCoroutine(ShockTimer());
    }
}

