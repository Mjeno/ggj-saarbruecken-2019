using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Sprite SPressKey; //0
    public Sprite SMainMenu; //1
    public Sprite SHowToPlay; //2
    public Sprite SCredits; //3
    bool BMPressKey;
    bool BMMainMenu;
    bool BMHowToPlay;
    bool BMCredits;

    //TODO - Press any Key

    // Start is called before the first frame update
    void Start()
    {
        BMPressKey = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BMPressKey)
        {
            if (Input.anyKeyDown)
            {
                GetComponent<SpriteRenderer>().sprite = SMainMenu;
                BMPressKey = false;
                BMMainMenu = true;
                //Debug.Log("Any Key");
            }
        }
        else if (BMMainMenu)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                GetComponent<SpriteRenderer>().sprite = SHowToPlay;
                BMMainMenu = false;
                BMHowToPlay = true;
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                GetComponent<SpriteRenderer>().sprite = SCredits;
                BMMainMenu = false;
                BMCredits = true;
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                Application.Quit();
            }
        }
        else if (BMHowToPlay)
        {
            if (Input.anyKeyDown)
            {
                GetComponent<SpriteRenderer>().sprite = SMainMenu;
                BMHowToPlay = false;
                BMMainMenu = true;
            }
        }
        else if (BMCredits)
        {
            if (Input.anyKeyDown)
            {
                GetComponent<SpriteRenderer>().sprite = SMainMenu;
                BMCredits = false;
                BMMainMenu = true;
            }
        }
    }
}
