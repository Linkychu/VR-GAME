using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class EnemyToggle : MonoBehaviour
{
    [SerializeField]private InputActionProperty shootActionReference;
    // Start is called before the first frame update

    [SerializeField]private Rigidbody rb;
    [SerializeField]private NavMeshAgent cubeNavemesh;
    [SerializeField] private GameObject Righthand;
    private Transform rightHandPos;
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        cubeNavemesh = GetComponent<NavMeshAgent>();
       // rightHandPos = Righthand.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enable()
    {
        cubeNavemesh.enabled = false;
        rb.isKinematic = false;
    }
  
   public void Renable()
   {
       cubeNavemesh.enabled = true;
       rb.isKinematic = true;
   }

}
