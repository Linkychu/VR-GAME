using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
    public Rigidbody windPrefab;
    private GunHolder gunHolder;
    void Start()
    {

        gunHolder = GetComponentInParent<GunHolder>();
        shootActionReference.action.performed += Shootwind;

    }

    // Update is called once per frame
    void Update()
    {
        shootingPos = origin.transform.position;
        origin1 = GetComponentInChildren<Transform>();
        origin2 = origin1.transform.position;



    }
    void Shootwind(InputAction.CallbackContext context)
    {
        
        weaponNumber = gunHolder.buttonCount;
        if (weaponNumber == 1)
            {
                Rigidbody wind = Instantiate(windPrefab, origin.transform.position, Quaternion.identity);
                wind.velocity = transform.TransformDirection(Vector3.up * 20);
                Destroy(wind.gameObject, 10);
            }
    }
    
}
