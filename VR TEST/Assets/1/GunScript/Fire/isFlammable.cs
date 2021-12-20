using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class isFlammable : MonoBehaviour
{
    public bool onFire;
    private float fireSeconds = 5f;
    [SerializeField] private GameObject fireObject;
    private GameObject fire;
    private SystemicProperties _systemicProperties;
    public AudioClip flameclip;
    private AudioSource flameSound;
    private bool onWater;
    void Start()
    {
        _systemicProperties = GameObject.FindWithTag("GameManager").GetComponent<SystemicProperties>();
        flameSound = GetComponent<AudioSource>();
        flameSound.playOnAwake = false;
        flameSound.clip = flameclip;

    }

    // Update is called once per frame
    void Update()
    {
        if (onFire)
        {
            fire.transform.position = gameObject.transform.position;
            flameSound.Play();
        }

        if (onWater)
        {
            StartCoroutine(Water());
            Destroy(fire);
            onFire = false;
        }

        // if (_systemicProperties.Temperature > 500)
        // {
        //    FireInstantiate();
        // }
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

       if (other.gameObject.CompareTag("Water"))
       {
           onWater = true;
           StartCoroutine(Water());
       }
       

    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            onWater = true;
        }

        else
        {
            onWater = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Water"))
        {
            onWater = true;
        }

        else
        {
            onWater = false;
        }
    }

    public void FireInstantiate()
    {
        if (!onWater)
        {
            fire = Instantiate(fireObject, gameObject.transform.position, Quaternion.identity);
            flameSound.Play();
            fire.transform.localScale = gameObject.transform.localScale * 4f;
            onFire = true;
            fire.transform.parent = gameObject.transform;
            StartCoroutine(FireTimer());
        }
    }

    IEnumerator FireTimer()
    {
        yield return new WaitForSeconds(fireSeconds);
        onFire = false;
        flameSound.Stop();
        Destroy(fire);
    }

    IEnumerator Water()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(fire);
        onFire = false;
        
    }
}
