using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityEffect : MonoBehaviour
{
    // Start is called before the first frame update
    
    float speed = 20;
    private Rigidbody rb;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  (transform.forward + new Vector3(0, 0, speed) * Time.deltaTime);
    }
}
