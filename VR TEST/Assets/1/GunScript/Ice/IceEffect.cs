using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private bool frozen = true;
    [SerializeField] private float speed; 
    private Transform objectTransform;
    [SerializeField] private GameObject iceBlock;
    [SerializeField] private float Damage = 100;
    [SerializeField] private IceBlock _iceBlock;
    public Collider objectCol;
    public Rigidbody objectRb;
    public GameObject[] iceBlocks;
    private float numberOfIceBlocks;
    private SystemicProperties _systemicProperties;
    public bool FreezeWater;
    private AudioSource _audioSource;
    public AudioClip iceEffect;
    public GameObject water;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _systemicProperties = GameObject.FindWithTag("GameManager").GetComponent<SystemicProperties>();
        _audioSource = GetComponent<AudioSource>();
    }

    
    // Update is called once per frame

    private void Update()
    {
        if (_systemicProperties.Temperature > 500)
        {
            Destroy(gameObject, 0.01f);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        
            if (other.gameObject.CompareTag("Water"))
            {
                FreezeWater = true;
                _audioSource.clip = iceEffect;
            }


            if (other.gameObject.CompareTag("Fire"))
            {
                Instantiate(water, transform.position, Quaternion.identity);
                Destroy(gameObject);
                
            }
            
            
            Destroy(gameObject, 0.5f);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            
            Destroy(gameObject);
            
        }

        if (other.gameObject.CompareTag("Water"))
        {
            FreezeWater = true;
            _audioSource.clip = iceEffect;
        }
    }
}
