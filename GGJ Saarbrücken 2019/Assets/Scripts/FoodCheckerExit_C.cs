using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCheckerExit_C : MonoBehaviour
{
    GameObject goPlayer;

    void Start() {
        goPlayer = GameObject.Find("FoodChecker");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision)
        {


            switch (collision.gameObject.GetComponent<Meal>().currentType)
            {
                case (Meal.mealType.drink):
                    FoodBar_C.barLenght += 10;
                    FoodChecker.essenDaTrinken = false;
                    FoodKombo_C.KomboMoeglich = false;
                    Destroy(collision.gameObject);
                    FoodKombo_C.KomboMoeglich = false;
                    goPlayer.GetComponent<FoodChecker>().updateAnimation("bEat");
                    break;

                case (Meal.mealType.veggie):
                    FoodBar_C.barLenght += 10;
                    FoodChecker.essenDaVeggie = false;
                    FoodKombo_C.KomboMoeglich = false;
                    Destroy(collision.gameObject);
                    FoodKombo_C.KomboMoeglich = false;
                    goPlayer.GetComponent<FoodChecker>().updateAnimation("bEat");
                    break;

                case (Meal.mealType.meat):
                    FoodBar_C.barLenght += 10;
                    FoodChecker.essenDaFleisch = false;
                    FoodKombo_C.KomboMoeglich = false;
                    Destroy(collision.gameObject);
                    FoodKombo_C.KomboMoeglich = false;
                    goPlayer.GetComponent<FoodChecker>().updateAnimation("bEat");
                    break;

                case (Meal.mealType.inedible):
                    Time.timeScale = 0;
                    FoodChecker.essenDaInedible = false;
                    FoodKombo_C.KomboMoeglich = false;
                    Destroy(collision.gameObject);
                    FoodKombo_C.KomboMoeglich = false;
                    goPlayer.GetComponent<FoodChecker>().updateAnimation("bEat");
                    break;

                case (Meal.mealType.dessert):
                    FoodChecker.essenDaDessert = false;
                    Point_C.Points += FoodChecker.PointMulti *20;
                    FoodKombo_C.KomboAnzahl++;
                    goPlayer.GetComponent<FoodChecker>().updateAnimation("bGoodFood");
                    Destroy(collision.gameObject); break;



            }



        }


    }
}
