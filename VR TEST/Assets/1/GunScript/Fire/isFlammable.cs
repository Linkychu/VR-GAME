using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isFlammable : MonoBehaviour
{
    public bool onFire;
    private float fireSeconds = 5f;
    [SerializeField] private GameObject fireObject;
    private GameObject fire;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onFire)
        {
            fire.transform.position = gameObject.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            if (!onFire)
            {
                Destroy(other.gameObject);

                FireInstantiate();
            }

            else
            {
                return;
            }
        }
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
       if (other.gameObject.GetComponent<isFlammable>())//.onFire == true)
       {
           isFlammable _flammable = other.gameObject.GetComponent<isFlammable>();
           if((_flammable.onFire == false) && onFire == true)
            _flammable.FireInstantiate();
           
       }
       

    }

        public void FireInstantiate()
    {
        fire = Instantiate(fireObject, gameObject.transform.position,Quaternion.identity);
        fire.transform.localScale = gameObject.transform.localScale * 4f;
        onFire = true;
        fire.transform.parent = gameObject.transform;
        StartCoroutine(FireTimer());
    }

    IEnumerator FireTimer()
    {
        yield return new WaitForSeconds(fireSeconds);
        onFire = false;
        Destroy(fire);
    }
}
