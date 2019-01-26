using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealSpawner : MonoBehaviour
{
	GameObject goMeal;
	Coroutine SpawningRoutine;
	bool bStageTwo, bStageThree, bStageFour, bStageFive;
    // Start is called before the first frame update
    void Start()
    {
        SpawningRoutine = StartCoroutine("SpawnMeal", 2.5f);
    }

    void Update()
    {
    	//Debug.Log("Time.time: " + Time.time);
    	if (Time.time > 15 && Time.time < 30 && !bStageTwo) {
    		StopCoroutine(SpawningRoutine);
    		SpawningRoutine = StartCoroutine("SpawnMeal", 2f);
    		bStageTwo = true;
    	}
    	if (Time.time > 30 && Time.time < 45 && !bStageThree) {
    		StopCoroutine(SpawningRoutine);
    		SpawningRoutine = StartCoroutine("SpawnMeal", 1.5f);
    		bStageThree = true;
    	}
    	if (Time.time > 45 && Time.time < 60 && !bStageFour) {
    		StopCoroutine(SpawningRoutine);
    		SpawningRoutine = StartCoroutine("SpawnMeal", 1f);
    		bStageFour = true;
    	}
    	if (Time.time > 75 && !bStageFive) {
    		StopCoroutine(SpawningRoutine);
    		SpawningRoutine = StartCoroutine("SpawnMeal", 0.75f);
    		bStageFive = true;
    	}
    }

    IEnumerator SpawnMeal(float fInterval)
    {
    	while(this){
        	goMeal = Instantiate (Resources.Load ("Meal", typeof(GameObject))) as GameObject;
        	yield return new WaitForSeconds(fInterval);
        }
    }
}
