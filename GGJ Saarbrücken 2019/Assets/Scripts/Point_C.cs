using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point_C : MonoBehaviour
{
    public Text foreGround, backGround;
    public static int Points;

    // Start is called before the first frame update
    void Start()
    {

        Points = 0;

    }

    // Update is called once per frame
    void Update()
    {
        foreGround.text = "" + Points;
        backGround.text = "" + Points;
    }
}
