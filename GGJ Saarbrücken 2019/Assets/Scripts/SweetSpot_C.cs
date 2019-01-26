using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetSpot_C : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            FoodChecker.onSweatSpot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision)
        {
            FoodChecker.onSweatSpot = false;
        }
    }
}
