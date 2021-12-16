using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.iOS;
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
       SecondaryActionReference.action.performed += VRInputDown;
      



    }

    private void VRInputUp(InputAction.CallbackContext obj)
    {
        buttonCount = currentselectedWeapon;
        buttonCount++;
        buttonCount %= weapons.Count;
        WeaponSwitch(buttonCount);
    }

    private void VRInputDown(InputAction.CallbackContext obj)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
      
    }


    public void WindInstantiate()
    {
        Vector3 rot = new Vector3(90, 90, 90);
        GameObject windG = Instantiate(gun1, hands.transform.position, Quaternion.identity);
        windG.transform.Rotate(rot);
        windG.transform.parent = gameObject.transform;
        weapons.Add(windG as GameObject);
    }

    public void ElectricInstantiate()
    {
        Vector3 rot = new Vector3(00, 00, 00);
        GameObject electricG = Instantiate(gun3, hands.transform.position, Quaternion.identity);
        electricG.transform.Rotate(rot);
        electricG.transform.parent = gameObject.transform;
        weapons.Add(electricG);
    }

    public void FireInstantiate()
    {
        Vector3 rot = new Vector3(00, 00, 00);
        GameObject fireG = Instantiate(gun4, hands.transform.position, Quaternion.identity);
        fireG.transform.Rotate(rot);
        fireG.transform.parent = gameObject.transform;
        weapons.Add(fireG);
    }

    public void IceInstantiate()
    {
        Vector3 rot = new Vector3(90, 90, 90);
        GameObject iceG = Instantiate(gun2, hands.transform.position, Quaternion.identity);
        iceG.transform.Rotate(rot);
        iceG.transform.parent = gameObject.transform;
        weapons.Add(iceG);
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
