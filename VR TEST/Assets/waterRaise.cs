using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class waterRaise : MonoBehaviour
{

    private SystemicProperties _systemicProperties;

    public GameObject waterObject;

    public float waterRaiseSpeed = 1;

    public Material water2Material;

    private Collider waterCollider;
    private Vector3 startPos;
    private Vector3 endPos;

    private float waterRaiseDist;
    public PhysicMaterial water;
    public PhysicMaterial ice;

    private float startTime;

    private float journeyLength;

    private float fractionOfJourney;

    private bool reset;

    public Animator animator;
    public AnimationClip waterRaised;

    public AnimationClip waterLowered;

    private Rigidbody rb;

    public Collider otherWaterCol;

    private Renderer waterRend;
    private Renderer waterRend2;

    public Material iceM;
    public Material waterM;

    public bool Frozen;

    private PhysicMaterial bouncy;

    public LayerMask waterL;

    public LayerMask iceL;

    private GameObject water2;
    // Start is called before the first frame update
    void Start()
    {
        waterCollider = GetComponent<Collider>();
        startPos = new Vector3(-15.8000002f, -4.5999999f, 27.5f);
        endPos = new Vector3(-15.8000002f, 1.20000005f, 27.5f);
        _systemicProperties = GameObject.FindWithTag("GameManager").GetComponent<SystemicProperties>();

        startTime = 0;
        fractionOfJourney = 0;
        journeyLength = Vector3.Distance(startPos, endPos);

        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
        

        waterRend = GetComponent<Renderer>();
        waterRend2 = GetComponentInChildren<Renderer>();

        bouncy = GetComponentInChildren<PhysicMaterial>();

        water2 = GetComponentInChildren<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {

        if (_systemicProperties.snow == true)
        {
            Freeze();
        }

        if (_systemicProperties.sun == true)
        {
            Unfreeze();
        }
        
        if (waterObject.activeInHierarchy == true)
        {

           animator.Play("WaterIncrease");

        StartCoroutine(LowerWater());
        }
        
      

        if (_systemicProperties.sun == true)
        {
            gameObject.transform.position = new Vector3(0, -10, 0);
        }
    }
    
    
    IEnumerator LowerWater()
    {
        yield return new  WaitUntil(() => waterObject.activeInHierarchy == false);
        animator.Play("WaterDecrease");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            if (!Frozen)
            {
                Freeze();
            }
        }

        if (other.gameObject.CompareTag("Fire"))
        {
            if (Frozen)
            {
                Unfreeze();
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            if (!Frozen)
            {
                Freeze();
            }
        }
        
        if (other.gameObject.CompareTag("Fire"))
        {
            if (Frozen)
            {
                Unfreeze();
            }
        }
    }
    
    

    public void Freeze()
    {
        Frozen = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        waterCollider.isTrigger = false;
        otherWaterCol.isTrigger = true;
        waterCollider.material = ice;
        waterRend.material = iceM;
        waterRend2.material = iceM;
        otherWaterCol.material = ice;
        gameObject.layer = iceL;
        water2.layer = iceL;
        gameObject.tag = "Ice";
        water2.tag = "Ice";



    }

    public void Unfreeze()
    {
        rb.constraints = RigidbodyConstraints.None;
        waterCollider.isTrigger = true;
        otherWaterCol.isTrigger = false;
        waterCollider.material = water;
        waterRend.material = waterM;
        waterRend2.material = water2Material;
        otherWaterCol.material = bouncy;
        gameObject.layer = waterL;
        water2.layer = waterL;
        Frozen = false;
        gameObject.tag = "Water";
        water2.tag = "Water";

    }
}
