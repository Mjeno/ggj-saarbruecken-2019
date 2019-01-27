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
    static bool BCatSpawned;

    void Awake() {
    	BCatSpawned = false;
    	/*if(GOCat) {
    		GOCat.GetComponent<Cat_Enconuter>().destroyCat();
    	}*/
    }

    // Start is called before the first frame update
    void Start()
    {
        NextCatTime = GetNextCatTime();
    }

    // Update is called once per frame
    void Update()
    {
        if(NextCatTime > 0f && !BCatSpawned)
        {
            NextCatTime -= Time.deltaTime;
            Debug.Log("NextCatTime -= Time.deltaTime: " + (NextCatTime -= Time.deltaTime));
        }
        else if (NextCatTime <= 0f && !BCatSpawned)
        {
            Debug.Log("Setting to true");
            BCatSpawned = true;
            SpawnCat();
            NextCatTime = GetNextCatTime();
        }
    }

    //Setzt die Zeit bis die Katze das nächste man kommt
    float GetNextCatTime()
    {
        float FCatTimeGenerated;
        Debug.Log("Nächste CatTime wird generiert.");

        FCatTimeGenerated = Random.Range(FCatSpawnTimeMIN, FCatSpawnTimeMAX);
        Debug.Log("Nächste CatTime ist: " + FCatTimeGenerated + ".");
        NextCatTime = FCatTimeGenerated;
        return FCatTimeGenerated;
    }

    void SpawnCat()
    {
        Debug.Log("Spawning Cat.");

        if(Random.Range(-1, 1) < 0)
        {
            GameObject cat = Instantiate(GOCat, TrCatSpawnL);
            cat.GetComponent<Cat_Enconuter>().GOCatSpawn = gameObject;
            cat.GetComponent<Cat_Enconuter>().BSpawnedRight = false;
            cat.GetComponent<SpriteRenderer>().flipX = true;
            cat.GetComponent<Cat_Enconuter>().V2Destination = new Vector2(-2, -1);
        }
        else
        {
            GameObject cat = Instantiate(GOCat, TrCatSpawnR);
            cat.GetComponent<Cat_Enconuter>().GOCatSpawn = gameObject;
            cat.GetComponent<Cat_Enconuter>().BSpawnedRight = true;
            cat.GetComponent<Cat_Enconuter>().V2Destination = new Vector2(2, -1);
        }
    }
        
    public void StartNextCat()
    {
        BCatSpawned = false;
        Debug.Log("Start next cat.");
    }
}
