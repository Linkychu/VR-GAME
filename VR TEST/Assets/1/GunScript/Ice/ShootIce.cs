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
    private float speed = 20;
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
        TryInitialize();
        shootActionReference.action.performed += Shootice;
        gunHolder = GetComponentInParent<GunHolder>();

    }

    // Update is called once per frame
    void Update()
    {
        origin1 = GetComponentInChildren<Transform>();
        origin2 = origin1.transform.position;
        shootingPos = origin.transform.position;

       
        TryInitialize();

      
    }

    void TryInitialize()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        InputDeviceCharacteristics controllerCharacteristics = InputDeviceCharacteristics.Right;
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, inputDevices);
        foreach (var device in inputDevices)
        {
           
        }

        if (inputDevices.Count > 0)
        {
            targetDevice = inputDevices[0];
        }
    }

    void Shootice(InputAction.CallbackContext context)
    {
        
        weaponNumber = gunHolder.buttonCount;
            if (weaponNumber == 1)
            {
                Rigidbody ice = Instantiate(icePrefab, origin2, origin.transform.rotation);
                ice.velocity = transform.TransformDirection(Vector3.up * 20);
                Destroy(ice.gameObject, 2);
            }

    }
    
}

