﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCheckerExit_C : MonoBehaviour
{
    GameObject goPlayer;
    public AudioSource ASFail;
    public AudioSource ASPerdect;


    void Start() {
        goPlayer = GameObject.Find("FoodChecker");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Meal>())
        {
                switch (collision.gameObject.GetComponent<Meal>().currentType)
                    {
                    case (Meal.mealType.drink):
                        FoodBar_C.barLenght += 30;
                        FoodChecker.essenDaTrinken = false;
                        FoodKombo_C.KomboMoeglich = false;
                        Destroy(collision.gameObject);
                        FoodKombo_C.KomboMoeglich = false;
                        goPlayer.GetComponent<FoodChecker>().updateAnimation("bEat");
                        ASFail.Play();
                        break;
            
                    case (Meal.mealType.veggie):
                        FoodBar_C.barLenght += 30;
                        FoodChecker.essenDaVeggie = false;
                        FoodKombo_C.KomboMoeglich = false;
                        Destroy(collision.gameObject);
                        FoodKombo_C.KomboMoeglich = false;
                        goPlayer.GetComponent<FoodChecker>().updateAnimation("bEat");
                        ASFail.Play();
                        break;
            
                    case (Meal.mealType.meat):
                        FoodBar_C.barLenght += 30;
                        FoodChecker.essenDaFleisch = false;
                        FoodKombo_C.KomboMoeglich = false;
                        Destroy(collision.gameObject);
                        FoodKombo_C.KomboMoeglich = false;
                        goPlayer.GetComponent<FoodChecker>().updateAnimation("bEat");
                        ASFail.Play();
                        break;
            
                    case (Meal.mealType.inedible):
                        GameOver.GameOverNow = true;
                        FoodChecker.essenDaInedible = false;
                        FoodKombo_C.KomboMoeglich = false;
                        Destroy(collision.gameObject);
                        FoodKombo_C.KomboMoeglich = false;
                        goPlayer.GetComponent<FoodChecker>().updateAnimation("bEat");
                        ASFail.Play();
                        break;
            
                    case (Meal.mealType.dessert):
                        FoodChecker.essenDaDessert = false;
                        Point_C.Points += FoodChecker.PointMulti *20;
                        FoodKombo_C.KomboAnzahl++;
                        goPlayer.GetComponent<FoodChecker>().updateAnimation("bGoodFood");
                        Destroy(collision.gameObject);
                        ASPerdect.Play();
                        break;
                    }
            
        }
    }

}
