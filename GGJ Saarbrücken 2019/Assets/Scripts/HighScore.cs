using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public Text TextHighScore;
  
   

    // Start is called before the first frame update
    void Start()
    {
        TextHighScore.text = PlayerPrefs.GetInt("Highscore",0).ToString();
        
    }

    // Update is called once per frame
    void Update()
    {

       

        PlayerPrefs.SetInt("Highscore", Point_C.Points);
       

        if (Point_C.Points > PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", Point_C.Points);
            TextHighScore.text = (Point_C.Points.ToString());
        }


       


    }
}
