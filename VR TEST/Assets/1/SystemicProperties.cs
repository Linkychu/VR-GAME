using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Bolt;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class SystemicProperties : MonoBehaviour
{

    private Transform windOrigin;
    private Vector3 windOriginPos;

    [SerializeField] private GameObject wind;
    [SerializeField] private float timer = 5f;
    private GameObject windCopy;

    private GameObject lightningCopy;
    private int count;
    private int Rng;
    private bool Spawn;
    private int Seed;

    private GameObject[] fireList;
    public GameObject rain;
    public bool windd;
    public bool sun;
    public bool snow;
    public bool thunder;

    private int i = 0;


    public GameObject lightning;
   [SerializeField] private Material wMaterial;
   [SerializeField] private Material Normal;
   [SerializeField] private Material Sun;
   [SerializeField] private Material Snow;
   [SerializeField] private Material Thunder;

   public ParticleSystem rainW;

   public ParticleSystem snowW;
   public GameObject snowflake;


   private AudioSource _source;
   public AudioClip heat;
   public AudioClip tornado;
   private Vector3 spawnCoords;

   public int Temperature;

   public AudioClip lightningClip;

   // Start is called before the first frame update
    void Start()
    {
        Spawn = false;
        count = 0;
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (sun == true)
        {
            Temperature += 10;
        }
        SeedFinder();

        fireList = GameObject.FindGameObjectsWithTag("Fire");

        if (snow == true)
        {
            Temperature -= 10;
        }
        if (fireList.Length > 10)
        {
            i = 11;
            Destroy(fireList[i], 0.002f);
        }
    


    }

    void SeedFinder()
    {
        if (!Spawn)
        {
            Seed = Random.Range(0, 1000);
            spawnCoords.x = Random.Range(-70, 40);
            spawnCoords.z = Random.Range(-62.8f, 76.9f);
            

            if (!Spawn && count == 0 && Seed > 20 && Seed < 40)
            {

                Spawn = true;
            }

        }


        if (Spawn == true & count == 0)

        {

            while (count == 0)
            {
                Rng = Random.Range(0, 10);
            
                switch (Rng)
                {
                    case 1:
                    {
                        count = 1;
                        Randomise();
                        break;
                    }

                    case 2:
                    {
                        count += 1;
                        Randomise();
                        break;
                    }

                    case 3:
                    {
                        count += 1;
                        Randomise();
                        break;
                    }

                    case 4:
                    {
                        count += 1;
                        Randomise();
                        break;
                    }

                    default:
                    {
                        return;
                        break;
                    }
                }

            }
            
        }

    }

    void Randomise()
    {
        if (Rng == 1 & Spawn == true && count == 1)
               
        {
            Wind();
        }

        if (Rng == 2 & Spawn && count == 1)
        {
            Heat();
        }

        if (Rng == 3 & Spawn && count == 1)
        {
            Lightning();
        }

        if (Rng == 4 & Spawn && count == 1)
        {
            Cold();
        }
        
    }





    public void Wind()
    {

        if (Spawn == true && count == 1)
        {
            rain.SetActive(true);
            rainW.Play();
            windd = true;
            RenderSettings.skybox = wMaterial;
            windOrigin = GameObject.FindWithTag("Centerpoint").GetComponent<Transform>();
            windOriginPos = windOrigin.transform.position;
            windOriginPos = spawnCoords;
            windCopy = (GameObject) Instantiate(wind, windOriginPos, Quaternion.identity);
            _source.clip = tornado;
            _source.Play();
            StartCoroutine(WindSeconds());


            IEnumerator WindSeconds()
            {
                yield return new WaitForSeconds(timer);
                Destroy(windCopy, 0f);
                rain.SetActive(false);
                rainW.Stop();
                Rng = Random.Range(0, 4);
                Seed = Random.Range(0, 101);
                _source.clip = null;
                StartCoroutine(Reset());
                
                
            }
        }
    }

    public void Heat()
    {
        RenderSettings.skybox = Sun;
        sun = true;
        _source.clip = heat;
        _source.Play();
        StartCoroutine(Reset());

    }

    public void Cold()
    {
        RenderSettings.skybox = Snow;
        snow = true;
        snowflake.SetActive(true);
        snowW.Play();
        StartCoroutine(SnowTimer());

        IEnumerator SnowTimer()
        {
            yield return new WaitForSeconds(timer);
            snowW.Stop();
            snowflake.SetActive(false);
            StartCoroutine(Reset());
        }
    }

    public void Lightning()
    {
        thunder = true;
        RenderSettings.skybox = Thunder;
        rain.SetActive(true);
        rainW.Play();
        _source.clip = lightningClip;

        _source.loop = false;
        _source.Play();

        lightningCopy = Instantiate(lightning, spawnCoords, Quaternion.identity);

        StartCoroutine(LightningReset());


        IEnumerator LightningReset()
        {
            yield return new WaitForSeconds(timer / 4);
            Rng = Random.Range(0, 4);
            Seed = Random.Range(0, 101);
            rain.SetActive(false);
            rainW.Stop();
            StartCoroutine(Reset());
            Destroy(lightningCopy, 0.00000001f);
            
        }


    }
    
    
    
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(timer);
        RenderSettings.skybox = Normal;
        windd = false;
        sun = false;
        snow = false;
        thunder = false;
        Temperature = 0;
        Spawn = false;
        _source.loop = true;
        _source.Stop();
        yield return new WaitForSeconds(timer * 2);
        count = 0;
        SeedFinder();
        rain.SetActive(false);
        rainW.Stop();
        _source.clip = null;


    }
}
