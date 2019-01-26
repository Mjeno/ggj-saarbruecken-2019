using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Spawn : MonoBehaviour
{
    public float FCatSpawnTimeMIN;
    public float FCatSpawnTimeMAX;
    public float NextCatTime;
    public GameObject GOCat;
    public Transform TrCatSpawnL;
    public Transform TrCatSpawnR;
    bool BCatSpawned;
    float FCatTimeGenerated;


    // Start is called before the first frame update
    void Start()
    {
        StartNextCat();
    }

    // Update is called once per frame
    void Update()
    {
     

        if(NextCatTime > 0f)
        {
            NextCatTime -= Time.deltaTime;
        }
        else if (NextCatTime <= 0f && !BCatSpawned)
        {
            BCatSpawned = true;
            SpawnCat();
        }


    }

    //Setzt die Zeit bis die Katze das nächste man kommt
    float GetNextCatTime()
    {
        Debug.Log("Nächste CatTime wird generiert.");

        FCatTimeGenerated = Random.Range(FCatSpawnTimeMIN, FCatSpawnTimeMAX);
        Debug.Log("Nächste CatTime ist: " + FCatTimeGenerated + ".");

        return FCatTimeGenerated;
    }

    void SpawnCat()
    {
        Debug.Log("Spawning Cat.");

        if(Random.Range(-1, 1) < 0)
        {
            Instantiate(GOCat, TrCatSpawnL);
            GOCat.GetComponent<Cat_Enconuter>().BSpawnedRight = false;
        }
        else
        {
            Instantiate(GOCat, TrCatSpawnR);
            GOCat.GetComponent<Cat_Enconuter>().BSpawnedRight = true;
        }
        


    }
        
    
    public void StartNextCat()
    {
        NextCatTime = GetNextCatTime();
        Debug.Log("Cat Reset("+ NextCatTime +")");
        BCatSpawned = false;

    }
}
