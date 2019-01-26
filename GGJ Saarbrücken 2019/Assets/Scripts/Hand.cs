using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Vector3 V3HandKeyPos;
    public bool BHandSlapL = false;
    public bool BHandSlapR = false;
    public Sprite SSpriteKeys;
    public Sprite SSpriteMove;
    public Sprite SSpriteSlapRight;
    public Sprite SSpriteSlapLeft;
    public float fMausSpeed = 0.5f;
    public float fMausSpeedKap;
    public float fHandPower;
    bool bBlockHand;

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

        if (Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.L))
        {
            ResetHand();
            bBlockHand = true;
        }
        else
        {
            bBlockHand = false;
        }

        if (transform.position != V3HandKeyPos)
        {
            
            if (Input.GetKey(KeyCode.Mouse0))
            {

                if (MausH < 0)
                {
                    GetComponentInChildren<SpriteRenderer>().sprite = SSpriteSlapLeft;
                    BHandSlapL = false;
                    BHandSlapR = true;
                    //Debug.Log("Hand Slap Left.");
                    
                }
                else if (MausH > 0)
                {
                    GetComponentInChildren<SpriteRenderer>().sprite = SSpriteSlapRight;
                    BHandSlapL = true;
                    BHandSlapR = false;
                    //Debug.Log("Hand Slap Right.");
                }
                else
                {
                    BHandSlapL = false;
                    BHandSlapR = false;
                    GetComponentInChildren<SpriteRenderer>().sprite = SSpriteMove;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                GetComponentInChildren<SpriteRenderer>().sprite = SSpriteKeys;
                BHandSlapL = false;
                BHandSlapR = false;
            } else {
                GetComponentInChildren<SpriteRenderer>().sprite = SSpriteMove;
            }
        }
        if (!bBlockHand)
        {
            transform.Translate(MausH, MausV, 0); 
        }
    }
    void ResetHand()
    {
        Debug.Log("Hand wird zurück gesetztz");
        transform.position = V3HandKeyPos;
        GetComponentInChildren<SpriteRenderer>().sprite = SSpriteKeys;
    }


}
