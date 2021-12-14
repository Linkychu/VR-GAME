using System;
using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update

    private void Awake()
    {
   
   
    }

    void Start()
    {


        numbers = GetComponent<WeaponCount>();
        controller = GetComponentInParent<ActionBasedController>();
       // buttonCount = 0;
       WeaponCalculate();



    }

    // Update is called once per frame
    void Update()
    {
        buttonCount = numbers.i;
        WeaponCalculate();
    }
    
    
    void WeaponCalculate()
    {
        if (buttonCount == 0)
        {
            Debug.Log("Hands");
            hands.SetActive(true);
            gun1.SetActive(false);
            gun2.SetActive(false);
            gun3.SetActive(false);
            gun4.SetActive(false);
        }
        
        if (buttonCount == 1)
        {
            Debug.Log("Wind");
            hands.SetActive(false);
            gun1.SetActive(true);
            gun2.SetActive(false);
            gun3.SetActive(false);
            gun4.SetActive(false);
        }
            
        if (buttonCount == 2)
        {
            Debug.Log("Ice");
            hands.SetActive(false);
            gun1.SetActive(false);
            gun2.SetActive(true);
            gun3.SetActive(false);
            gun4.SetActive(false);
        }
        
        if (buttonCount == 3)
        {
            Debug.Log("Electric");
            hands.SetActive(false);
            gun1.SetActive(false);
            gun2.SetActive(false);
            gun3.SetActive(true);
            gun4.SetActive(false);
        }
            
        if (buttonCount == 4)
        {
            Debug.Log("Fire");
            hands.SetActive(false);
            gun1.SetActive(false);
            gun2.SetActive(false);
            gun3.SetActive(false);
            gun4.SetActive(true);
        }
            

    }
}
