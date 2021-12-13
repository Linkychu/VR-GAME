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

    public int buttonCount;
    private float PrimaryInput;


    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject gun4;

    private InputDevice targetDevice;
    private float SecondaryInput;
    //private InputActionAsset playerControls;

    
        
    [SerializeField] private GameObject GlobalController;

    private PlayerInput _inputControls;

    private GlobalControls _controls;

    private bool PM1;
    private bool SM1;

    private int state;
    
    
    [SerializeField] private InputActionProperty PrimaryActionReference;
    [SerializeField] private InputActionProperty SecondaryActionReference;

        
        private InputAction SelectGun;
    // Start is called before the first frame update
    

    void Start()
    {
        buttonCount = 0;
        WeaponCalculate();
        Allowed = true;
        PrimaryActionReference.action.performed += VRInputUp;
        SecondaryActionReference.action.performed += VRInputDown;


    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = buttonCount;

        if (previousSelectedWeapon != buttonCount)
        {
            WeaponCalculate();
        }

    }

    void VRInputUp(InputAction.CallbackContext context)
    {
        if (buttonCount >= transform.childCount - 1)
        {
            buttonCount = 0;
        }

        else
        {
            buttonCount++;
        }

    }

    void VRInputDown(InputAction.CallbackContext context)
    {

        if (buttonCount <= 0)
        {
            buttonCount = transform.childCount - 1;
        }

        else
        {
            buttonCount--;
        }
    }

    // void PrimaryInputCheck()
    // {
    //     
    //     if (Allowed && targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
    //     {
    //         Debug.Log("Checks Button");
    //         StartCoroutine(Checker());
    //         primaryButtonValue = false;
    //         PrimaryButtonPressed = true;
    //         Allowed = false;
    //
    //     }
    //     
    //     
    //     else
    //     {
    //         PrimaryButtonPressed = false;
    //     }
    //
    //     
    //     IEnumerator Checker()
    //     {
    //         Debug.Log("Yes");
    //         yield return new WaitForSeconds(0.25f);
    //         buttonCount += 1;
    //         Allowed = true;
    //     }
    //
    //     
    // }
    //     
   
        
    //
    // void SecondaryInputCheck()
    // {
    //     targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
    //     if (secondaryButtonValue)
    //     {
    //         buttonCount -= Convert.ToSingle(secondaryButtonValue);
    //         SecondaryButtonPressed = true;
    //     }
    //
    //     else
    //     {
    //         SecondaryButtonPressed = false;
    //     }
    //
    // }
    

    void WeaponCalculate()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == buttonCount)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;


        }
        //     int WeaponNumber = buttonCount;
        //     switch (WeaponNumber)
        //         {
        //             case 0:
        //                 gun1.SetActive(true);
        //                 gun2.SetActive(false);
        //                 gun3.SetActive(false);
        //                 gun4.SetActive(false);
        //                 break;
        //             case 1:
        //                 gun1.SetActive(false);
        //                 gun2.SetActive(true);
        //                 gun3.SetActive(false);
        //                 gun4.SetActive(false);
        //                 break;
        //             case 2:
        //                 gun1.SetActive(false);
        //                 gun2.SetActive(false);
        //                 gun3.SetActive(true);
        //                 gun4.SetActive(false);
        //                 break;
        //             case 3:
        //                 gun1.SetActive(false);
        //                 gun2.SetActive(false);
        //                 gun3.SetActive(false);
        //                 gun4.SetActive(true);
        //                 break;
        //             default:
        //                 return;
        //         }
    }
}
