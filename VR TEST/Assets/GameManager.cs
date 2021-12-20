using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor.UIElements;
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

    private float globalSpeed;

    public int waveCount;

    private float spawnCoordsX;
    private float spawnCoordsZ;

    public GameObject EnemiesSpawn;
    private FollowPlayer cubeAI;
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        actionReference.action.performed += Pause;
        waveCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
      
        StartCoroutine(SpawnHealth());
        SpawnCoords();
        CheckForEnemies();
    }

    void SpawnCoords()
    {
         spawnCoordsX = Random.Range(-23.09f, 23.04f);
         spawnCoordsZ = Random.Range(-23.8f, 23.53f);

         spawnCoords = new Vector3(spawnCoordsX, 0.2f, spawnCoordsZ);
    }
    public void Pause(InputAction.CallbackContext callbackContext)
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
        }

        else
        {
            Time.timeScale = 1;
            paused = false;
        }
        
        
    }

    public void Unpause()
    {
        Time.timeScale = 1;
    }

    private void SpawnEnemies()
    {
     
        Destroy(EnemiesSpawn);

        Vector3 spawnCoords = new Vector3(0,9.03999996f,12.1800003f);
        Vector3 spawnRotation = new Vector3(0, 0, 180);
        EnemiesSpawn = Instantiate(WavePrefab, spawnCoords, Quaternion.identity);
        waveCount += 1;
    }

    void CheckForEnemies()
    {
        if (EnemiesSpawn.transform.childCount == 0)
        {
            cubeAI = EnemiesSpawn.GetComponentInChildren<FollowPlayer>();
            SpawnEnemies();
        }
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
