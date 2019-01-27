using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool GameOverNow= false;


    private void Update()
    {
        
    if(GameOverNow == true)
        {
            GameOverNow = false;
            SceneManager.LoadScene("GameOver");
       
        }

    }

}
