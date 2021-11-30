using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using CommonUsages = UnityEngine.XR.CommonUsages;
using InputDevice = UnityEngine.XR.InputDevice;

public class GunHolder : MonoBehaviour
{

    public bool Allowed;

    private bool PrimaryButtonPressed;
    private bool SecondaryButtonPressed;

    public float buttonCount;
    private float PrimaryInput;


    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject gun4;
    public GameObject gun5;

    private InputDevice targetDevice;
    private float SecondaryInput;
    //private InputActionAsset playerControls;

    
        
    [SerializeField] private GameObject GlobalController;

    private PlayerInput _inputControls;

    private GlobalControls _controls;

    private bool PM1;
    private bool SM1;

    private int state;
    
    
    //[SerializeField] private InputActionProperty PrimaryActionReference;
    //[SerializeField] private InputActionProperty SecondaryActionReference;
    

    //private InputAction SelectGun;
    // Start is called before the first frame update
    

    void Start()
    {
        Allowed = true;
        TryInitialize();
        WeaponCalculate();
        //PrimaryActionReference.action.performed += VRInputUp;
        //SecondaryActionReference.action.performed += VRInputDown;


    }

    // Update is called once per frame
    void Update()
    {
        WeaponCalculate();
        TryInitialize();

        PrimaryInputCheck();
        SecondaryInputCheck();

    }

    void PrimaryInputCheck()
    {
        
        if (Allowed && targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            StartCoroutine(Checker());
            primaryButtonValue = false;
            PrimaryButtonPressed = true;
            Allowed = false;

        }
        
        
        else
        {
            PrimaryButtonPressed = false;
        }

        
        IEnumerator Checker()
        {
            yield return new WaitForSeconds(0.2f);
            buttonCount += 1;
            Allowed = true;
        }

        
    }
        
   
        

    void SecondaryInputCheck()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
        if (secondaryButtonValue)
        {
            buttonCount -= Convert.ToSingle(secondaryButtonValue);
            SecondaryButtonPressed = true;
        }

        else
        {
            SecondaryButtonPressed = false;
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

    void WeaponCalculate()
    {
        
        switch (buttonCount)
                {
                    case 0:
                        gun1.SetActive(true);
                        gun2.SetActive(false);
                        gun3.SetActive(false);
                        gun4.SetActive(false);
                        gun5.SetActive(false);
                        break;
                    case 1:
                        gun1.SetActive(false);
                        gun2.SetActive(true);
                        gun3.SetActive(false);
                        gun4.SetActive(false);
                        gun5.SetActive(false);
                        break;
                    case 2:
                        gun1.SetActive(false);
                        gun2.SetActive(false);
                        gun3.SetActive(true);
                        gun4.SetActive(false);
                        gun5.SetActive(false);
                        break;
                    case 3:
                        gun1.SetActive(false);
                        gun2.SetActive(false);
                        gun3.SetActive(false);
                        gun4.SetActive(true);
                        gun5.SetActive(false);
                        break;
                    case 4:
                        gun1.SetActive(false);
                        gun2.SetActive(false);
                        gun3.SetActive(false);
                        gun4.SetActive(false);
                        gun5.SetActive(true);
                        break;
                    case -1f:
                        buttonCount = 4;
                        break;

                    default:
                        buttonCount = 0;
                        state = 1;
                        break;
                }

            }
        }
