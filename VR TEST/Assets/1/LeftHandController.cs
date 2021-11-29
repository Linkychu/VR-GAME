using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftHandController : MonoBehaviour
{
    // Start is called before the first frame update

    private ActionBasedController Lcontroller;
    public LeftHand Lhand;
    void Start()
    {
        Lcontroller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        Lhand.SetGrip(Lcontroller.selectAction.action.ReadValue<float>());
        Lhand.SetTrigger(Lcontroller.activateAction.action.ReadValue<float>());
    }
}
