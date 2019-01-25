using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Spawn : MonoBehaviour
{
    public float FCatSpawnTimeMIN = 30;
    public float FCatSpawnTimeMAX = 120;
    float NextCatTime;


    // Start is called before the first frame update
    void Start()
    {
        NextCatTime = GetNextCatTime();
    }

    // Update is called once per frame
    void Update()
    {
        NextCatTime -= Time.deltaTime;
        if (NextCatTime <= 0)
        {
            SpawnCat();
        }
    }

    //Setzt die Zeit bis die Katze das nächste man kommt
    float GetNextCatTime()
    {
        Debug.Log("Nächste CatTime wird generiert.");

        float FCatTimeGenerated = Random.Range(FCatSpawnTimeMIN, FCatSpawnTimeMAX);
        Debug.Log("Nächste CatTime ist: " + FCatTimeGenerated + ".");

        return FCatTimeGenerated;
    }

    void SpawnCat()
    {
        Debug.Log("Spawning Cat.");
        //TODO Add Cat to Spawn
        NextCatTime = GetNextCatTime();
    }

    public void StartNextCatTime()
        {
        Debug.Log("Next Cat Time wird gestratet.");
        GetNextCatTime();
        }
}
