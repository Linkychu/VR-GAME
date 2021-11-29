using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.XR;

public class Animations : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator main;
    private InputDevice targetDevice;
    void Start()
    {
        main = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TryAnimations();
    }

    void TryAnimations()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            main.SetFloat("Trigger", triggerValue);
            Debug.Log(triggerValue);
        }

        else
        {
            main.SetFloat("Trigger", 0);
            Debug.Log(triggerValue);
        }
        
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            main.SetFloat("Grip", gripValue);
            Debug.Log(triggerValue);
        }

        else
        {
            main.SetFloat("Grip", 0);
            Debug.Log(triggerValue);
        }
    }
}
