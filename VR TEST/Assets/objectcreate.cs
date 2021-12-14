using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

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

            bool abletospawn;
            if (NumberofIns < 10)
            {
                abletospawn = true;
            }

            weaponNumber = gunHolder.buttonCount;
            Rigidbody objectIns = Instantiate(objectPrefab, transform.position + Distance, transform.rotation);



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
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10f, instantiated))
            {
                Destroy(hit.transform);
            }
        }
    }
}
