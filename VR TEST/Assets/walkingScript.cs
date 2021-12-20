using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class walkingScript : MonoBehaviour
{
    public LocomotionSystem playerLoco;
    private float timer = 0.0f;

    private Rigidbody rb;
    private PlayerController _playerController;
    public AudioSource move;
    public ActionBasedContinuousMoveProvider movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      _playerController =  GetComponent<PlayerController>();
    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        if (_playerController.isGrounded)
        {
            
        }
    }
}
