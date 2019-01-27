using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealSpawner : MonoBehaviour
{
	GameObject goMeal;
	Coroutine SpawningRoutine;
	bool bStageTwo, bStageThree, bStageFour, bStageFive;
    Animator animGrandma;

    // Start is called before the first frame update
    void Awake() {
        if (SpawningRoutine != null) {
            StopCoroutine(SpawningRoutine);
        }
    }

    void Start()
    {
        SpawningRoutine = StartCoroutine("SpawnMeal", 2.5f);
        animGrandma = this.GetComponent<Animator>();
    }

    void Update()
    {
    	//Debug.Log("Time.timeSinceLevelLoad: " + Time.timeSinceLevelLoad);
    	if (Time.timeSinceLevelLoad > 20 && Time.timeSinceLevelLoad < 40 && !bStageTwo) {
    		StopCoroutine(SpawningRoutine);
    		SpawningRoutine = StartCoroutine("SpawnMeal", 2f);
    		bStageTwo = true;
            animGrandma.SetBool("stage-2", true);
    	}
    	if (Time.timeSinceLevelLoad > 40 && Time.timeSinceLevelLoad < 60 && !bStageThree) {
    		StopCoroutine(SpawningRoutine);
    		SpawningRoutine = StartCoroutine("SpawnMeal", 1.5f);
    		bStageThree = true;
            animGrandma.SetBool("stage-3", true);
    	}
    	if (Time.timeSinceLevelLoad > 60 && Time.timeSinceLevelLoad < 80 && !bStageFour) {
    		StopCoroutine(SpawningRoutine);
    		SpawningRoutine = StartCoroutine("SpawnMeal", 1f);
    		bStageFour = true;
            animGrandma.SetBool("stage-4", true);
    	}
    	if (Time.timeSinceLevelLoad > 80 && !bStageFive) {
    		StopCoroutine(SpawningRoutine);
    		SpawningRoutine = StartCoroutine("SpawnMeal", 0.75f);
    		bStageFive = true;
            animGrandma.SetBool("stage-5", true);
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
