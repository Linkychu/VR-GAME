using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SystemicProperties : MonoBehaviour
{

    private Transform windOrigin;
    private Vector3 windOriginPos;

    [SerializeField] private GameObject wind;
    [SerializeField] private float timer = 5f;
    private GameObject windCopy;

    private int count;
    private int Rng;
    private bool Spawn;
    private int Seed;

    // Start is called before the first frame update
    void Start()
    {
        Spawn = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        SeedFinder();
        


    }

    void SeedFinder()
    {
        if (!Spawn)
        {
            Seed = Random.Range(0, 101);
            

            if (!Spawn && count == 0 && Seed < 20)
            {

                Spawn = true;
            }

        }


        if (Spawn == true & count == 0)

        {

            while (count == 0)
            {
                Rng = Random.Range(0, 4);
            
                switch (Rng)
                {
                    case 1:
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
    }





    public void Wind()
    {

        if (Spawn == true && count == 1)
        {
            windOrigin = GameObject.FindWithTag("Centerpoint").GetComponent<Transform>();
            windOriginPos = windOrigin.transform.position;
            windCopy = (GameObject) Instantiate(wind, windOriginPos, Quaternion.identity);
            StartCoroutine(WindSeconds());


            IEnumerator WindSeconds()
            {
                yield return new WaitForSeconds(timer);
                Destroy(windCopy, 0f);
                Rng = Random.Range(0, 4);
                Seed = Random.Range(0, 101);
                StartCoroutine(Reset());

                IEnumerator Reset()
                {
                    yield return new WaitForSeconds(timer);
                    Spawn = false;
                    yield return new WaitForSeconds(timer * 2);
                    count = 0;
                    SeedFinder();
                    
                }

            }
        }
    }

    public void Lightning()
    {
        
    }
}
