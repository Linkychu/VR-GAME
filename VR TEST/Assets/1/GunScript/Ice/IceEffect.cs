using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private bool frozen = true;
    [SerializeField] private float speed; 
    private Transform objectTransform;
    [SerializeField] private GameObject iceBlock;
    [SerializeField] private float Damage = 100;
    [SerializeField] private IceBlock _iceBlock;
    public Collider objectCol;
    public Rigidbody objectRb;
    public GameObject[] iceBlocks;
    private float numberOfIceBlocks;
    private SystemicProperties _systemicProperties;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _systemicProperties = GameObject.FindWithTag("GameManager").GetComponent<SystemicProperties>();
    }

    
    // Update is called once per frame

    private void Update()
    {
        if (_systemicProperties.Temperature > 500)
        {
            Destroy(gameObject, 0.01f);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        
        iceBlocks = GameObject.FindGameObjectsWithTag("IceBlock");
        numberOfIceBlocks = iceBlocks.Length;
        objectRb = other.gameObject.GetComponent<Rigidbody>();
            if (other.rigidbody != null && !(other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Ice")))
            {
                objectTransform = other.gameObject.transform;
                objectCol = other.gameObject.GetComponent<Collider>();

               // if (numberOfIceBlocks < 1)
                //{
                    GameObject InstantiatedIce = Instantiate(iceBlock,
                        other.transform.position + new Vector3(0, 0.1f, 0), transform.rotation);
                    _iceBlock = InstantiatedIce.GetComponent<IceBlock>();
                    InstantiatedIce.transform.localScale = 1.1f * objectTransform.localScale;
                //}

               //if (numberOfIceBlocks > 1)
              // {
             //      Destroy(iceBlocks[2]);
              // }

            }


            if (other.gameObject.CompareTag("Fire"))
            {
                Destroy(gameObject);
            }
            
            
            Destroy(gameObject, 0.5f);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            Destroy(gameObject);
        }
    }
}
