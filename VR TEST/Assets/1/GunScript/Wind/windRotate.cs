using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windRotate : MonoBehaviour
{
    // Start is called before the first frame update

    public float yRot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, yRot, 0);
        yRot++;
    }
}
