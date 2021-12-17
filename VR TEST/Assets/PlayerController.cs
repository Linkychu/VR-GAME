using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private InputActionProperty jumpActionReference;
    [SerializeField] private float jumpForce = 500f;

    [SerializeField] private Transform groundCheck;
    private Rigidbody rb;
    private XROrigin _xrOrigin;
    private CapsuleCollider _collider;

    [SerializeField]private LayerMask Ground;
    private float radius;

    private bool isGrounded => 
    Physics.CheckSphere(groundCheck.transform.position, 1.1f, Ground);
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _xrOrigin = GetComponent<XROrigin>();
        jumpActionReference.action.performed += OnJump;
    }

    // Update is called once per frame
    void Update()
    {
        var center = _xrOrigin.CameraInOriginSpacePos;
        _collider.center = new Vector3(center.x,_xrOrigin.CameraInOriginSpaceHeight /2 , center.z);
        _collider.height = _xrOrigin.CameraInOriginSpaceHeight;
        
        if (gameObject.transform.position.y < -50)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(1);
        }
    }

    void OnJump(InputAction.CallbackContext obj)
    {
        if(!isGrounded) return;
        rb.AddForce((Vector3.up * jumpForce));
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }
}
