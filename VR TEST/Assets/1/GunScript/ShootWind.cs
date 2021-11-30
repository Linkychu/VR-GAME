using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public GameObject windPrefab;
    void Start()
    {
         shootingTransform = GetComponentInChildren<Transform>();
        TryInitialize();
        
    }

    // Update is called once per frame
    void Update()
    {
        shootingPos = shootingTransform.transform.position;
        TryInitialize();

        bool triggerValue;
        if (targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) &&
            triggerValue)
        {
            Shootwind();
        }
    }

    void TryInitialize()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        InputDeviceCharacteristics controllerCharacteristics = InputDeviceCharacteristics.Right;
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, inputDevices);
        foreach (var device in inputDevices)
        {
            Debug.Log(device.name + device.characteristics);
        }

        if (inputDevices.Count > 0)
        {
            targetDevice = inputDevices[0];
        }
    }

    void Shootwind()
    {
        
        RaycastHit somethingHit;
        if (Physics.Raycast(shootingPos, Vector3.forward, out somethingHit, 1f))
        {
            var wind = Instantiate(windPrefab, shootingPos, Quaternion.identity);
            Destroy(wind.gameObject, 10);
        }

    }
    
}
