using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
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

    
    public GameObject hands;
    private InputDevice targetDevice;
    private float SecondaryInput;
    //private InputActionAsset playerControls;

    
        
    [SerializeField] private GameObject GlobalController;

    private PlayerInput _inputControls;

    private GlobalControls _controls;

    private bool PM1;
    private bool SM1;

    private int state;

    private ActionBasedController controller;

    private int previousSelectedWeapon;

    private WeaponCount numbers;
    
    private int timer = 0;
        
        private InputAction SelectGun;

        private int i = 0;

        public List<GameObject> weapons = new List<GameObject>();

        private int currentselectedWeapon;


        private int GunPickUp;
        [SerializeField] private InputActionProperty PrimaryActionReference;
        [SerializeField] private InputActionProperty SecondaryActionReference;
    // Start is called before the first frame update

    private void Awake()
    {
   
   
    }

    void Start()
    {


         currentselectedWeapon = 0;
        numbers = GetComponent<WeaponCount>();
        controller = GetComponentInParent<ActionBasedController>();
       // buttonCount = 0;
       weapons[currentselectedWeapon].gameObject.SetActive(true);
       PrimaryActionReference.action.performed += VRInputUp;

      



    }

    private void VRInputUp(InputAction.CallbackContext obj)
    {
        buttonCount = currentselectedWeapon;
        buttonCount++;
        buttonCount %= weapons.Count;
        WeaponSwitch(buttonCount);
    }

 
    // Update is called once per frame
    void Update()
    {
        
      
    }


    public void WindInstantiate()
    {
        weapons.Add(gun1);
        buttonCount = currentselectedWeapon;
        buttonCount++;
        buttonCount %= weapons.Count;
        WeaponSwitch(buttonCount);
        
    }

    public void ElectricInstantiate()
    {
        weapons.Add(gun3);
        buttonCount = currentselectedWeapon;
        buttonCount++;
        buttonCount %= weapons.Count;
        WeaponSwitch(buttonCount);
    
    }

    public void FireInstantiate()
    {
       weapons.Add(gun4);
   
       buttonCount = currentselectedWeapon;
       buttonCount++;
       buttonCount %= weapons.Count;
       WeaponSwitch(buttonCount);
    }

    public void IceInstantiate()
    {
       weapons.Add(gun2);
       buttonCount = currentselectedWeapon;
       buttonCount++;
       buttonCount %= weapons.Count;
       WeaponSwitch(buttonCount);  
    }
    void WeaponSwitch(int weaponIndex)
    {
        weapons[currentselectedWeapon].gameObject.SetActive(false);
        weapons[weaponIndex].gameObject.SetActive(true);
        currentselectedWeapon = weaponIndex;
    }
    
    

    
    // void WeaponCalculate(int WeaponIndex)
    // {
    //     if (buttonCount == 0)
    //     {
    //
    //         hands.SetActive(true);
    //         gun1.SetActive(false);
    //         gun2.SetActive(false);
    //         gun3.SetActive(false);
    //         gun4.SetActive(false);
    //     }
    //
    //     if (buttonCount == 1)
    //     {
    //
    //         hands.SetActive(false);
    //         gun1.SetActive(true);
    //         gun2.SetActive(false);
    //         gun3.SetActive(false);
    //         gun4.SetActive(false);
    //     }
    //
    //     if (buttonCount == 2)
    //     {
    //
    //         hands.SetActive(false);
    //         gun1.SetActive(false);
    //         gun2.SetActive(true);
    //         gun3.SetActive(false);
    //         gun4.SetActive(false);
    //     }
    //
    //     if (buttonCount == 3)
    //     {
    //
    //         hands.SetActive(false);
    //         gun1.SetActive(false);
    //         gun2.SetActive(false);
    //         gun3.SetActive(true);
    //         gun4.SetActive(false);
    //     }
    //
    //     if (buttonCount == 4)
    //     {
    //
    //         hands.SetActive(false);
    //         gun1.SetActive(false);
    //         gun2.SetActive(false);
    //         gun3.SetActive(false);
    //         gun4.SetActive(true);
    //     }
    //
    //
    // }
}
