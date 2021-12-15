using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class objectcreate : MonoBehaviour
{
    [SerializeField]private Transform origin;
    private Vector3 origin2;
    private Transform origin1;
    [SerializeField]private InputAction _inputAction;
    [SerializeField]private InputActionProperty createActionReference;
    [SerializeField] private InputActionProperty deleteActionReference;
    public Rigidbody objectPrefab;
    private GunHolder gunHolder;
    [SerializeField] private XRRayInteractor rayInteractor;

    bool abletospawn;
 
    private int weaponNumber;

    [SerializeField]private LayerMask instantiated;
    [SerializeField]private Vector3 Distance;
    // Start is called before the first frame update
    void Start()
    {
        gunHolder = GetComponentInParent<GunHolder>();
        createActionReference.action.performed += Createobject;
        deleteActionReference.action.performed += Deleteobject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Createobject(InputAction.CallbackContext context)
    {
        weaponNumber = gunHolder.buttonCount;

        if (weaponNumber == 0)
        {
            GameObject[] objectInstantiates = GameObject.FindGameObjectsWithTag("Instantiated");
            float NumberofIns = objectInstantiates.Length;

           
            if (NumberofIns < 10)
            {
                abletospawn = true;
            }

            weaponNumber = gunHolder.buttonCount;

            if (abletospawn)
            {
                Rigidbody objectIns = Instantiate(objectPrefab, transform.position + Distance, transform.rotation);
            }



            if (NumberofIns > 10)
            {
                abletospawn = false;
            }
        }

    }

    void Deleteobject(InputAction.CallbackContext context)
    {
        if (weaponNumber == 0)
        {
            
            if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
               ObjectInstant TargetObject = hit.transform.GetComponent<ObjectInstant>();
               TargetObject.DeleteObject();
            }
        }
    }
}
