using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour
{
    private Rigidbody objectRb;
    private Joint iceJoint;
    private IceEffect _iceEffect;
    private Collider otherCol;
    private Collider _collider;
    private SystemicProperties _systemicProperties;

    private int seconds = 8;
    private int doubleSeconds;
    private void OnEnable()
    {
        _iceEffect = GetComponent<IceEffect>();
    }

    private void Start()
    {
        _collider = GetComponent<Collider>();
        StartCoroutine(Timer());
   
        _systemicProperties = GameObject.FindWithTag("GameManager").GetComponent<SystemicProperties>();
        doubleSeconds = seconds * 2;


    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(9.9f);

    }

    private void Update()
    {
        if (_systemicProperties.snow != true)
        {
            Destroy(gameObject, seconds);
        }

        else
        {
            Destroy(gameObject, doubleSeconds);
        }


        if (_systemicProperties.Temperature > 500)
        {
            Destroy(gameObject, 0.01f);
        }
        
    }

    
    // private void OnTriggerEnter(Collider other)
    // {
    //     objectRb  = other.gameObject.GetComponent<Rigidbody>();
    //     if (objectRb != null & !(other.gameObject.CompareTag("Player") || !(other.gameObject.CompareTag("Ice"))))
    //     {
    //         otherCol = other.gameObject.GetComponent<Collider>();
    //         objectRb.isKinematic = true;
    //         objectRb.constraints = RigidbodyConstraints.FreezeAll;
    //         otherCol.isTrigger = true;
    //         _collider.isTrigger = false;
    //         iceJoint.connectedBody = objectRb;
    //         iceJoint.breakForce = 100;
    //         iceJoint.breakTorque = 100;
    //
    //         StartCoroutine(JointBreak());
    //
    //         
    //         Ice();
    //     }
    //
    //     else
    //     {
    //         objectRb = null;
    //     }
    // }

    
    

        //
        // IEnumerator JointBreak()
        // {
        //     yield return new WaitForSeconds(2);
        //     Destroy(iceJoint);
        //     _collider.isTrigger = true;
        //     otherCol.isTrigger = false;
        //     objectRb.constraints = RigidbodyConstraints.None;
        //     objectRb.isKinematic = false;
        //     OnJointBreak(100);
        //   
        //
        // }
        //
        // private void OnJointBreak(float breakForce)
        // {
        //     _collider.isTrigger = true;
        //     otherCol.isTrigger = false;
        //     objectRb.constraints = RigidbodyConstraints.None;
        //     objectRb.isKinematic = false;
        // }
}
