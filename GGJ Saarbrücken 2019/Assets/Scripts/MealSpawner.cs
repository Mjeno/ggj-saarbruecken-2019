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
    	if (Time.time > 10 && Time.time < 20 && !bStageTwo) {
    		StopCoroutine(SpawningRoutine);
    		SpawningRoutine = StartCoroutine("SpawnMeal", 2f);
    		bStageTwo = true;
    	}
    	if (Time.time > 20 && Time.time < 30 && !bStageThree) {
    		StopCoroutine(SpawningRoutine);
    		SpawningRoutine = StartCoroutine("SpawnMeal", 1.5f);
    		bStageThree = true;
    	}
    	if (Time.time > 30 && Time.time < 40 && !bStageFour) {
    		StopCoroutine(SpawningRoutine);
    		SpawningRoutine = StartCoroutine("SpawnMeal", 1f);
    		bStageFour = true;
    	}
    	if (Time.time > 40 && !bStageFive) {
    		StopCoroutine(SpawningRoutine);
    		SpawningRoutine = StartCoroutine("SpawnMeal", 0.5f);
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
