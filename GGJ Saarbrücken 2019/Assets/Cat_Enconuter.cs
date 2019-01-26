using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    

public class Cat_Enconuter : MonoBehaviour
{
    public GameObject GOHand;
    public GameObject GOCatSpawn;
    public bool BSpawnedRight;
    


    // Start is called before the first frame update
    void Start()
    {
        

     }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == GOHand.name)
        {
            if ((collision.gameObject.GetComponent<Hand>().BHandSlapR && BSpawnedRight) || (collision.gameObject.GetComponent<Hand>().BHandSlapL && !BSpawnedRight))
            {
                Debug.Log("Cat hit by Hand.");
                GOCatSpawn.GetComponent<Cat_Spawn>().StartNextCat();
                Destroy(this.gameObject);
            }

        }
        
    }

}
