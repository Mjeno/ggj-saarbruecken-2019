using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    

public class Cat_Enconuter : MonoBehaviour
{
    public GameObject GOHand;
    public GameObject GOCatSpawn;
    public bool BSpawnedRight;
    Rigidbody2D rb;
    public float FCatSlaySpeed = 5;
    Vector2 V2Kick;
    public Vector2 V2Destination;
 

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //V2Destination = new Vector2(-4 , -4);
        
    }

    private void Awake()
    {
       
    }

    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, V2Destination, 0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == GOHand.name)
        {
            if (collision.gameObject.GetComponent<Hand>().BHandSlapL && BSpawnedRight) 
            {
                Debug.Log("collision.gameObject.GetComponent<Hand>().BHandSlapR && !BSpawnedRight");
                rb.isKinematic = false;
                V2Kick = new Vector2(Random.Range(FCatSlaySpeed, FCatSlaySpeed*2), Random.Range(-FCatSlaySpeed*0.5f, FCatSlaySpeed * 0.5f));
                rb.velocity = V2Kick;
                destroyCat();
            } else if(collision.gameObject.GetComponent<Hand>().BHandSlapR && !BSpawnedRight)
            {
                Debug.Log("collision.gameObject.GetComponent<Hand>().BHandSlapL && BSpawnedRight");
                rb.isKinematic = false;
                V2Kick = new Vector2(Random.Range(-FCatSlaySpeed * 2, -FCatSlaySpeed), Random.Range(-FCatSlaySpeed * 0.5f, FCatSlaySpeed * 0.5f));
                rb.velocity = V2Kick;
                destroyCat();
            }
        }
        
    }

    void destroyCat()
    {
        Debug.Log("Cat hit by Hand.");
        GOCatSpawn.GetComponent<Cat_Spawn>().StartNextCat();
        StartCoroutine(WaitAndDestroy(1));
    }

    private IEnumerator WaitAndDestroy(float secs)
    {
        yield return new WaitForSeconds(secs);
        Destroy(gameObject);
    }

}
