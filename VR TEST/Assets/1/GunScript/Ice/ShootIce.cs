using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using InputDevice = UnityEngine.XR.InputDevice;

public class ShootIce : MonoBehaviour
{
    
    private Transform shootingTransform;
    private Vector3 shootingPos;

    public float weaponNumber;
    private ActionBasedController Rcontroller;
    [SerializeField]private float speed = 20;
    private InputDevice targetDevice;
    private GlobalControls _controls;

    [SerializeField]private Transform origin;
     private Vector3 origin2;
     private Transform origin1;
    [SerializeField]private InputAction _inputAction;
    [SerializeField]private InputActionProperty shootActionReference;
    public Rigidbody icePrefab;
    private GunHolder gunHolder;
  
    void Start()
    {
        shootActionReference.action.performed += Shootice;
        gunHolder = GetComponentInParent<GunHolder>();

    }

    // Update is called once per frame
    void Update()
    {
        origin1 = GetComponentInChildren<Transform>();
        origin2 = origin1.transform.position;
        shootingPos = origin.transform.position;
        

      
    }

    void Shootice(InputAction.CallbackContext context)
    {
        
        weaponNumber = gunHolder.buttonCount;
            if (gameObject.activeInHierarchy == true)
            {
                Rigidbody ice = Instantiate(icePrefab, origin2, origin.transform.rotation);
                ice.velocity = transform.TransformDirection(Vector3.up * 20);
                Destroy(ice.gameObject, 2);
            }

    }
    
}

