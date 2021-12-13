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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    // Update is called once per frame

    private void Update()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        
        iceBlocks = GameObject.FindGameObjectsWithTag("IceBlock");
        numberOfIceBlocks = iceBlocks.Length;
        objectRb = other.gameObject.GetComponent<Rigidbody>();
            if (other.rigidbody != null && !(other.gameObject.CompareTag("Player")))
            {
                objectTransform = other.gameObject.transform;
                objectCol = other.gameObject.GetComponent<Collider>();

                if (numberOfIceBlocks < 1)
                {
                    GameObject InstantiatedIce = Instantiate(iceBlock,
                        other.transform.position + new Vector3(0, 0.1f, 0), transform.rotation);
                    _iceBlock = InstantiatedIce.GetComponent<IceBlock>();
                    InstantiatedIce.transform.localScale = 1.1f * objectTransform.localScale;
                }

               if (numberOfIceBlocks > 1)
               {
                   Destroy(iceBlocks[2]);
               }

            }
            
            Destroy(gameObject, 0.5f);
    }


}
