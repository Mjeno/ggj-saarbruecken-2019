using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChecker : MonoBehaviour
{
    //Hilfe bei der Collisionsabfrage
    public static bool  essenDaTrinken; 
    public static bool  essenDaVeggie; 
    public static bool essenDaFleisch; 
    public static bool essenDaInedible;
    public static bool essenDaDessert;
  
    //Hilfe bei der ExitCollisionsabfrage
    public Sprite[] Sprites;
    private GameObject currentFood;

    public float FoodmeterDazu =10f;

    private void Update()
    {

        //DDR Element . / Abfrage + Punkte
        if (essenDaTrinken == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                essenDaTrinken = false;
                Point_C.Points += 10;
                Destroy(currentFood);
            }

            if(Input.GetKeyDown(KeyCode.L)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("Miep");
                Destroy(currentFood);
                FoodBar_C.barLenght += 10;
                essenDaTrinken = false;

            }

        }

        if(essenDaVeggie == true)
        {
            if (Input.GetKeyDown(KeyCode.L))
            { 
                Point_C.Points += 10;
                essenDaVeggie = false;
                Destroy(currentFood);
                
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K))
            {
                Destroy(currentFood);
                FoodBar_C.barLenght += 10;
                essenDaVeggie = false;
            }

        }

        if(essenDaFleisch == true)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Point_C.Points += 10;
                essenDaFleisch = false;
                Destroy(currentFood);
                
            }
            if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.K))
            {
                Destroy(currentFood);
                FoodBar_C.barLenght += 10;
                essenDaFleisch = false;
            }

        }

        if (essenDaInedible == true)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Point_C.Points += 10;
                essenDaInedible = false;
                Destroy(currentFood);
                
            }
            if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
            {
                Destroy(currentFood);
                FoodBar_C.barLenght += 10;
                essenDaInedible = false;
            }

        }

        if (essenDaDessert == true)
        {
            if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K))
            {
                essenDaDessert = false;
                Destroy(currentFood);

            }
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        currentFood = collision?.gameObject;// ? =
       /* if(collision != null)
        {
            currentFood = collision.gameObject;
       */ 
        if (collision)
        {
            switch (collision.gameObject.GetComponent<Meal>().currentType)
            {


                case (Meal.mealType.drink):
                    essenDaTrinken = true;
                    break;

                case (Meal.mealType.veggie):
                    essenDaVeggie = true; break;

                case (Meal.mealType.meat):
                    essenDaFleisch = true; break;

                case (Meal.mealType.inedible):
                    essenDaInedible = true; break;

                case (Meal.mealType.dessert):
                    essenDaDessert = true;
                    break;

            }
   
        }
    }

   

}
