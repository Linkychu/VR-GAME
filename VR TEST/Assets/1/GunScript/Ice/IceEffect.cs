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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    // Update is called once per frame
    void Update()
    {
        transform.position +=  (transform.forward + new Vector3(0, 0, speed) * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision other)
    {
        objectRb = other.gameObject.GetComponent<Rigidbody>();
            if (other.rigidbody != null &&
                (!(other.gameObject.CompareTag("Ice")) || !(other.gameObject.CompareTag("Player"))))
            {
                objectTransform = other.gameObject.transform;
                objectCol = other.gameObject.GetComponent<Collider>();
                objectRb.constraints = RigidbodyConstraints.FreezeAll;

                GameObject InstantiatedIce = Instantiate(iceBlock, other.transform.position + new Vector3(0, 0.1f, 0),
                    Quaternion.identity);
                _iceBlock = InstantiatedIce.GetComponent<IceBlock>();
                InstantiatedIce.transform.localScale = 1.1f * objectTransform.localScale;

            }
            
            Destroy(gameObject, 2);
    }


}
