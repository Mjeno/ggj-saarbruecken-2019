using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meal : MonoBehaviour
{
	Vector3 v3TargetPosition;
	float fSpeed;
	float fYPosition;
	SpriteRenderer srSpriteRenderer;
	public enum mealType {
		meat,
		veggie,
		inedible,
		drink,
		dessert
	}
	public mealType currentType;
	public Sprite[] arAllSprites;

    void Start()
    {
    	srSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
     	currentType = RandomizeMealType();
    	switch (currentType)
    	{
    		case(mealType.drink):
    			srSpriteRenderer.sprite = arAllSprites[0];
    			fYPosition = 1.75f;
    			break;
    		case(mealType.inedible):
    			srSpriteRenderer.sprite = arAllSprites[1];
    			fYPosition = 1.25f;
    			break;
    		case(mealType.veggie):
    			srSpriteRenderer.sprite = arAllSprites[2];
    			fYPosition = 1.25f;
    			break;
    		case (mealType.meat):
  	  			srSpriteRenderer.sprite = arAllSprites[3];
    			fYPosition = 0.75f;
    			break;
    		case (mealType.dessert):
    			srSpriteRenderer.sprite = arAllSprites[4];
    			fYPosition = RandomizeLane();
    			break;
    	}

    	fSpeed = 2f;
        this.transform.position = new Vector3 (-2.8f, fYPosition, 0);
        v3TargetPosition = new Vector3 (4, fYPosition, 0);
    }

    void Update() {
    	MoveToPlayer();
    }

    void MoveToPlayer() {
    	this.transform.position = Vector3.MoveTowards (this.transform.position, v3TargetPosition, fSpeed * Time.deltaTime);
    }

    mealType RandomizeMealType() {
    	int iMealType = Random.Range(0,5);
    	switch (iMealType) 
    	{
    		case(0):
    			return mealType.drink;
    			break;
    		case(1):
    			return mealType.inedible;
    			break;
    		case(2):
    			return mealType.veggie;
    			break;
    		case(3):
    			return mealType.meat;
    			break;
    		default:
    		  	return mealType.dessert;
    			break;
    	}
    }

    float RandomizeLane() {
    	// TO DO
    	int iLane = Random.Range(0,3);
    	switch (iLane) 
    	{
    		case(0):
    			return 1.75f;
    			break;
    		case(1):
    			return 1.25f;
    			break;
    		default:
    			return 0.75f;
    			break;
    	}
    }
}
