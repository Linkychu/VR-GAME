using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using CommonUsages = UnityEngine.XR.CommonUsages;
using InputDevice = UnityEngine.XR.InputDevice;

public class ShootWind : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform shootingTransform;
    private Vector3 shootingPos;

    private ActionBasedController Rcontroller;
    private float speed = 20;
    private InputDevice targetDevice;
    private GlobalControls _controls;
    public float weaponNumber;

    [SerializeField]private Transform origin;
    private Vector3 origin2;
    private Transform origin1;
    [SerializeField]private InputAction _inputAction;
    [SerializeField]private InputActionProperty shootActionReference;
    public GameObject windPrefab;
    private GunHolder gunHolder;
    void Start()
    {
        TryInitialize();
    
        gunHolder = GetComponentInParent<GunHolder>();

    }

    // Update is called once per frame
    void Update()
    {
        shootingPos = origin.transform.position;
        origin1 = GetComponentInChildren<Transform>();
        origin2 = origin1.transform.position;
        TryInitialize();
        shootActionReference.action.performed += Shootwind;

      
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

    void Shootwind(InputAction.CallbackContext context)
    {
        
        Debug.Log(shootingPos);
        RaycastHit somethingHit;
        
        if (Physics.Raycast(shootingPos, transform.TransformDirection(Vector3.forward), out somethingHit, 1f))
        {
             
             
            
             weaponNumber = gunHolder.buttonCount;
            if (weaponNumber == 0)
            {
                var wind = Instantiate(windPrefab, origin2, origin.transform.rotation);
                
                
                Destroy(wind.gameObject, 10);
                
            }
        }

    }
    
}
