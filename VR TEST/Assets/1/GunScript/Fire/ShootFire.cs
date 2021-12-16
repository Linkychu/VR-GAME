using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootFire : MonoBehaviour
{
    [SerializeField] private Rigidbody firePrefab;
    public float weaponNumber;
    private ActionBasedController Rcontroller;
    private GlobalControls _controls;
    [SerializeField]private Transform origin;
    private Vector3 origin2;
    private Transform origin1;
    [SerializeField]private InputAction _inputAction;
    [SerializeField]private InputActionProperty shootActionReference;
    [SerializeField] private float speed = 20;
    private GunHolder gunHolder;

    private Vector3 shootingPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        shootActionReference.action.performed += Shootfire;
        gunHolder = GetComponentInParent<GunHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        origin1 = GetComponentInChildren<Transform>();
        origin2 = origin1.transform.position;
        shootingPos = origin.transform.position;

    }

    void Shootfire(InputAction.CallbackContext context)
    {
        weaponNumber = gunHolder.buttonCount;
        if (gameObject.activeInHierarchy == true)
        {
            Rigidbody fire = Instantiate(firePrefab, origin2, origin.transform.rotation);
            fire.velocity = transform.TransformDirection(Vector3.forward * 20);
            Destroy(fire.gameObject, 2);
        }
    }
}
