using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChecker : MonoBehaviour
{
    //Hilfe bei der Collisionsabfrage
    public static bool essenDaTrinken; 
    public static bool essenDaVeggie; 
    public static bool essenDaFleisch; 
    public static bool essenDaInedible;
    public static bool essenDaDessert;

    GameObject goDog;
    GameObject goRejectedInedible;

    Animator eaterAnim;

    //Hilfe bei der ExitCollisionsabfrage
    public Sprite[] Sprites;
    private GameObject currentFood;

    public float FoodmeterDazu =10f;

    public static int PointMulti;

    //Sounds:
    public AudioSource ASFail;
    public AudioSource ASPerfect;
    public AudioSource ASWater;
    public AudioSource ASSweep;
    public AudioSource ASPot_Destruct;
    public AudioSource ASDogB;
    public AudioSource ASDogEat;

    void Start() {
    	eaterAnim = this.GetComponent<Animator>();
        goDog = GameObject.Find("Dog");
    }

    private void Update()
    {

        //DDR Element . / Abfrage + Punkte
        if (essenDaTrinken == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                essenDaTrinken = false;
                Point_C.Points += PointMulti *10;
                updateAnimation("bPour");
                Destroy(currentFood);
                FoodKombo_C.KomboAnzahl++;
                ASPerfect.Play();
                ASWater.Play();
            }

            if(Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K))
            {
                Destroy(currentFood);
                updateAnimation("bEat");
                FoodBar_C.barLenght += 30;
                essenDaTrinken = false;
                FoodKombo_C.KomboMoeglich = false;
                ASFail.Play();
            }
        }

        if(essenDaVeggie == true)
        {
            if (Input.GetKeyDown(KeyCode.L))
            { 
                Point_C.Points += PointMulti * 10;
                essenDaVeggie = false;
                updateAnimation("bThrow");
                goRejectedInedible = Instantiate (Resources.Load ("RejectedVeggie", typeof(GameObject))) as GameObject;
                Destroy(currentFood);
                FoodKombo_C.KomboAnzahl++;
                ASPerfect.Play();
                ASSweep.Play();
                ASPot_Destruct.PlayDelayed(1);
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K))
            {
                Destroy(currentFood);
                updateAnimation("bEat");
                FoodBar_C.barLenght +=  20;
                essenDaVeggie = false;
                FoodKombo_C.KomboMoeglich = false;
                ASFail.Play();
                
            }
        }

        if(essenDaFleisch == true)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Point_C.Points += PointMulti * 10;
                essenDaFleisch = false;
                updateAnimation("bFeed");
                goDog.GetComponent<Animator>().SetBool("gotsausage", true);
                Destroy(currentFood);
                FoodKombo_C.KomboAnzahl++;
                ASPot_Destruct.Play();
                ASDogB.Play();
                ASDogEat.PlayDelayed(0.5f);
                ASPerfect.Play();
            }
            if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.K))
            {
                Destroy(currentFood);
                updateAnimation("bEat");
                FoodBar_C.barLenght += 30;
                essenDaFleisch = false;
                FoodKombo_C.KomboMoeglich = false;
                ASFail.Play();
            }
        }

        if (essenDaInedible == true)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Point_C.Points += PointMulti * 10;
                essenDaInedible = false;
                goRejectedInedible = Instantiate (Resources.Load ("RejectedInedible", typeof(GameObject))) as GameObject;
                updateAnimation("bReturn");
                Destroy(currentFood);
                FoodKombo_C.KomboAnzahl++;
                ASPerfect.Play();
                ASSweep.Play();
                ASPot_Destruct.PlayDelayed(0.2f);
            }
            if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
            {
                Destroy(currentFood);
                GameOver.GameOverNow = true;
                ASFail.Play();

            }
        }

        if (essenDaDessert == true)
        {
            if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K))
            {
                essenDaDessert = false;
                Destroy(currentFood);
                FoodKombo_C.KomboMoeglich = false;
                
            }
        }

    }

    public void updateAnimation(string strNewAni) {
    	if(strNewAni != "bPour") {
    		eaterAnim.SetBool("bPour", false);
    	}
    	if(strNewAni != "bEat") {
    		eaterAnim.SetBool("bEat", false);
    	}
    	if(strNewAni != "bThrow") {
    		eaterAnim.SetBool("bThrow", false);
    	}
        if(strNewAni != "bReturn") {
            eaterAnim.SetBool("bReturn", false);
        }
    	if(strNewAni != "bFeed") {
    		eaterAnim.SetBool("bFeed", false);
    	}
        if(strNewAni != "bGoodFood") {
            eaterAnim.SetBool("bGoodFood", false);
        }
    	if(strNewAni != "bIdle") {
    		eaterAnim.SetBool("bIdle", false);
    		StartCoroutine(BackToIdle());
    	}
    	eaterAnim.SetBool(strNewAni, true);
    }

    IEnumerator BackToIdle() {
    	yield return new WaitForSeconds(0.3f);
    	updateAnimation("bIdle");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        currentFood = collision?.gameObject;// ? =
       /* if(collision != null)
        {
            currentFood = collision.gameObject;
       */ 
        if (collision.gameObject.GetComponent<Meal>())
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
