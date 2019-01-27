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
    Animator catAnim;
    float fSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        fSpeed = 0.1f;
        catAnim = this.GetComponent<Animator>();
        if(this.transform.position.x < V2Destination.x) {
            BSpawnedRight = false;
        } else {
            BSpawnedRight = true;
        }
        StartCoroutine(WalkToTarget());
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.timeSinceLevelLoad > 20 && Time.timeSinceLevelLoad < 30) {
            fSpeed = 0.125f;
        }
        if(Time.timeSinceLevelLoad > 30 && Time.timeSinceLevelLoad < 60) {
            fSpeed = 0.175f;
        }
    }

    IEnumerator WalkToTarget() {
        while ((this.transform.position.x < V2Destination.x && !BSpawnedRight) || (this.transform.position.x > V2Destination.x && BSpawnedRight)) {
            transform.position = Vector2.MoveTowards(transform.position, V2Destination, fSpeed);
            yield return 1;
        }
        catAnim.SetBool("standing", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == GOHand.name)
        {
            if (collision.gameObject.GetComponent<Hand>().BHandSlapL && BSpawnedRight) 
            {
                catAnim.SetBool("standing", false);
                catAnim.SetBool("cat-pushed", true);
                Debug.Log("collision.gameObject.GetComponent<Hand>().BHandSlapR && !BSpawnedRight");
                rb.isKinematic = false;
                V2Kick = new Vector2(Random.Range(FCatSlaySpeed, FCatSlaySpeed*2), Random.Range(-FCatSlaySpeed*0.5f, FCatSlaySpeed * 0.5f));
                rb.velocity = V2Kick;
                destroyCat();
            } else if(collision.gameObject.GetComponent<Hand>().BHandSlapR && !BSpawnedRight)
            {
                catAnim.SetBool("standing", false);
                catAnim.SetBool("cat-pushed", true);
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
