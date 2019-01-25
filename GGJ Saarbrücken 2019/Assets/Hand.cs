using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Vector3 V3HandKeyPos;
    bool BHandSlap = false;
    public Sprite SSpriteKeys;
    public Sprite SSpriteSlap;
    public float fMausSpeed = 0.5f;
    public float fMausSpeedKap;


    // Start is called before the first frame update
    void Start()
    {
        V3HandKeyPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float MausH = fMausSpeed * Input.GetAxis("Mouse X");
        float MausV = fMausSpeed * Input.GetAxis("Mouse Y");
        float MausSpeed = MausH + MausV;

        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        {
            ResetHand();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && transform.position != V3HandKeyPos)
        {
            BHandSlap = true;
            GetComponentInChildren<SpriteRenderer>().sprite = SSpriteSlap;
        } else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            BHandSlap = false;
            GetComponentInChildren<SpriteRenderer>().sprite = SSpriteKeys;
         
        }

        
        
        transform.Translate(MausH, MausV, 0); 
        

        

    }



    void ResetHand()
    {
        Debug.Log("Hand wird zurück gesetztz");
        transform.position = V3HandKeyPos;
    }


}
