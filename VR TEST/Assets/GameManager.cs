using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    public InputActionReference actionReference;

    public GameObject[] Enemies;

    public GameObject WavePrefab;

    public GameObject Health;

    private float numberofenemies;

    private Vector3 spawnCoords;

    private float spawnCoordsX;
    private float spawnCoordsZ;
    

    // Start is called before the first frame update
    void Start()
    {
        actionReference.action.performed += Pause;
       
        CheckForEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (numberofenemies < 1)
        {
            SpawnEnemies();
        }

        StartCoroutine(SpawnHealth());
        SpawnCoords();
    }

    void SpawnCoords()
    {
         spawnCoordsX = Random.Range(-23.09f, 23.04f);
         spawnCoordsZ = Random.Range(-23.8f, 23.53f);

         spawnCoords = new Vector3(spawnCoordsX, 0.2f, spawnCoordsZ);
    }
    public void Pause(InputAction.CallbackContext callbackContext)
    {
        Time.timeScale = 0;
        
    }

    public void Unpause()
    {
        Time.timeScale = 1;
    }

    private void SpawnEnemies()
    {
       
            for (int i = 0; i < 10; i++)
            {
                GameObject EnemiesWave = Instantiate(WavePrefab, spawnCoords, Quaternion.identity);
                EnemiesWave.SetActive(true);
                CheckForEnemies();
            
        }
    }

    void CheckForEnemies()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numberofenemies = Enemies.Length;
    }

    IEnumerator SpawnHealth()
    {
        yield return new WaitForSeconds(60);
        int seed = Random.Range(1, 5);

        if (seed == 4)
        {
            SpawnInstantiatedHealth();
            yield return new WaitForSeconds(60);
        }
    }

    void SpawnInstantiatedHealth()
    {
        
         GameObject healthIns = Instantiate(Health, spawnCoords, Quaternion.identity);
         GameObject[] healths = GameObject.FindGameObjectsWithTag("Health");
         int healthNum = healths.Length;

         if (healths.Length > 5)
         {
             Destroy(healthIns);
         }
         Destroy(healthIns, 30);
        
    }
    
}
