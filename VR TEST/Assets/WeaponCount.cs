using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponCount : MonoBehaviour
{
    [SerializeField] private InputActionProperty PrimaryActionReference;
    [SerializeField] private InputActionProperty SecondaryActionReference;

    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        PrimaryActionReference.action.performed += VRInputUp;
        SecondaryActionReference.action.performed += VRInputDown;
    }

   

    // Update is called once per frame
    void Update()
    {
        if (i >10)
        {
            i = 0;
        }

        if (i < -10)
        {
            i = transform.childCount;
        }
    }
    
    private void VRInputUp(InputAction.CallbackContext obj)
    {
        i++;
    }
    
    private void VRInputDown(InputAction.CallbackContext obj)
    {
        i--;
    }
}
