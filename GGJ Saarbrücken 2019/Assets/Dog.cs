using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{

	Animator dogAnim;

	void Start() {
		dogAnim = this.GetComponent<Animator>();
	}

    public void NormalizeDog() {
    	dogAnim.SetBool("gotsausage", false);
    }
}
