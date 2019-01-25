using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealSpawner : MonoBehaviour
{
	GameObject goMeal;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("SpawnMeal", 0, 1);
    }

    void SpawnMeal()
    {
        goMeal = Instantiate (Resources.Load ("Meal", typeof(GameObject))) as GameObject;
    }
}
