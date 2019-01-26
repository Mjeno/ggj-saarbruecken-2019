using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCheckerExit_C : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision)
        {


            switch (collision.gameObject.GetComponent<Meal>().currentType)
            {


                case (Meal.mealType.drink):
                    FoodBar_C.barLenght += 10;
                    FoodChecker.essenDaTrinken = false;
                    Destroy(collision.gameObject);

                    break;

                case (Meal.mealType.veggie):
                    FoodBar_C.barLenght += 10;
                    FoodChecker.essenDaVeggie = false;
                    Destroy(collision.gameObject);

                    break;

                case (Meal.mealType.meat):
                    FoodBar_C.barLenght += 10;
                    FoodChecker.essenDaFleisch = false;
                    Destroy(collision.gameObject);

                    break;

                case (Meal.mealType.inedible):
                    FoodChecker.essenDaInedible = false;
                    Destroy(collision.gameObject);

                    break;

                case (Meal.mealType.dessert):
                    FoodChecker.essenDaDessert = false;
                    Point_C.Points += 20; 
                    Destroy(collision.gameObject); break;



            }



        }


    }
}
