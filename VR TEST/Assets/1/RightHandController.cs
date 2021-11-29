using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandController : MonoBehaviour
{
    // Start is called before the first frame update

    private ActionBasedController Rcontroller;
    public RightHand Rhand;
    void Start()
    {
        Rcontroller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        Rhand.SetGrip(Rcontroller.selectAction.action.ReadValue<float>());
        Rhand.SetTrigger(Rcontroller.activateAction.action.ReadValue<float>());
    }
}
