using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private InputActionProperty jumpActionReference;
    [SerializeField] private float jumpForce = 500f;

    private Rigidbody rb;
    private XROrigin _xrOrigin;
    private CapsuleCollider _collider;

    private LayerMask Ground;
    private float radius;

    private bool isGrounded => 
    Physics.Raycast(new Vector2(transform.position.x, transform.position.y + 2.0f), Vector3.down, 2.0f, Ground);
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
        _collider.center = new Vector3(center.x, _collider.center.y, center.z);
        _collider.height = _xrOrigin.CameraInOriginSpaceHeight;
    }

    void OnJump(InputAction.CallbackContext obj)
    {
        if(!isGrounded) return;
        rb.AddForce((Vector3.up * jumpForce));
    }
    
}
