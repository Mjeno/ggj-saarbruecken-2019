using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FoodKombo_C : MonoBehaviour
{
    public Text ForKombo,BackKombo;
    public static int KomboAnzahl;
    public static  bool KomboMoeglich = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KomboMoeglich == false)
        {
            KomboAnzahl = 0;
            KomboMoeglich = true;
        }

        if (KomboAnzahl <= 10) {
            FoodChecker.PointMulti = 1;
            ForKombo.color = Color.white;
        }

        if (KomboAnzahl >= 10 && KomboAnzahl <= 20) {
            FoodChecker.PointMulti = 2;
            ForKombo.color = Color.grey;
        }

        if (KomboAnzahl >= 20 && KomboAnzahl <= 30)
        {
            FoodChecker.PointMulti = 3;
            ForKombo.color = Color.yellow;
        }

        if (KomboAnzahl >= 20 && KomboAnzahl <= 30)
        {
            FoodChecker.PointMulti = 4;
            ForKombo.color = new Color(241, 127, 67);
        }

        if (KomboAnzahl >= 20 && KomboAnzahl <= 30)
        {
            FoodChecker.PointMulti = 5;
            ForKombo.color = Color.red;
        }
        ForKombo.text = "Kombo: " + KomboAnzahl;
        BackKombo.text = "Kombo: " + KomboAnzahl;

    }
}
