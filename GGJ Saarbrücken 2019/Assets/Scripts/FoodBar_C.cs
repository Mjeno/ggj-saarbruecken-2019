using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBar_C : MonoBehaviour
{
    public static float barLenght = 0f;
    private float trueBarLenght;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += 1 * Time.deltaTime;

        if(timer >= 1)
        {
            barLenght -= 1.5f;
            timer = 0f;
        }

        if(barLenght <= 0)
        {
            barLenght = 0;
        }

        if(barLenght >= 100)
        {
            barLenght = 100;
            GameOver.GameOverNow = true;
        }

        trueBarLenght = barLenght / 100f;
        gameObject.transform.localScale = new Vector3(trueBarLenght, 1, 1);

    }
}
