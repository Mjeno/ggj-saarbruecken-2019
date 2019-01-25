using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChecker : MonoBehaviour
{

    bool essenDaTrinken=true; //Platzhalter für die Component der Meal Klasse
    bool essenDaBrokolie=true; //Platzhalter für die Component der Meal Klasse
    bool essenDaFleisch=true; //Platzhalter für die Component der Meal Klasse
    bool essenDaOma=true; //Platzhalter für die Component der Meal Klasse
    bool essenDaLecker = true;

    public float FoodmeterDazu =10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            FoodBar_C.barLenght += FoodmeterDazu;

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (essenDaTrinken== true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Die Pflanze sieht durstig aus");
                //Punkte dazu
                
            }


        }
        if (essenDaBrokolie==true)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("IHH lern fliegen");
                //Punkte dazu
                

            }

        }
        if (essenDaFleisch== true)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Kein Fleisch ! :P");
                //Punkte dazu
               
            }

        }
        if (essenDaOma== true)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("Nimm das Oma!");
                //Punkte dazu
               
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (essenDaTrinken== true)
        {
            Debug.Log("Ihh (trinken)");
            FoodBar_C.barLenght += FoodmeterDazu;
            // Punkte-
            //Destroy
        }

        if (essenDaFleisch == true)
        {
            Debug.Log("Ihh (fleisch)");
            FoodBar_C.barLenght += FoodmeterDazu;
            // Punkte-
            //Destroy

        }

        if (essenDaBrokolie == true)
        {
            Debug.Log("Ihh (brokolie)");
            FoodBar_C.barLenght += FoodmeterDazu;
            //Punkte-
            //Destroy
        }

        if (essenDaOma == true)
        {
            Debug.Log("Ihh (oma)");
            //Verloren
            //Destroy
        }

        if (essenDaLecker == true)
        {
            Debug.Log("Lecker!");
            //Kotzmeter=
            //Extra Punkte
            //Destroy
        }

    }

}
