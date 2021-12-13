using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    private InputAction _thumbstick;
    private bool _isActive;
    [SerializeField] private TeleportationProvider provider;

    void Start()
    {
        rayInteractor.enabled = false;

        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        var cancel = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;

        _thumbstick = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
        _thumbstick.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isActive)
            return;


        if (_thumbstick.triggered)
            return;

        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            _isActive = false;
            return;
        }

        // TeleportRequest request = new TeleportRequest()
        // {
        //     destinationPosition = hit.point,
        //     //     destinationRotation = ,
        //     //     // matchOrientation = , 
        //     //     // requestTime = ,
        //     //     
        //     // }
        //     // ;
        //     // provider.QueueTeleportRequest()
        // };
    }

    void OnTeleportActivate(InputAction.CallbackContext context)
        {
            rayInteractor.enabled = true;
            _isActive = true;
        }

        void OnTeleportCancel(InputAction.CallbackContext context)
        {
            rayInteractor.enabled = false;
            _isActive = false;
        }
    }
