using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public Sprite SActivMenue;
    public Sprite SPressKey; //0
    public Sprite SMainMenu; //1
    public Sprite SHowToPlay; //2
    public Sprite SCredits; //3
    bool BMPressKey;
    bool BMMainMenu;
    bool BMHowToPlay;
    bool BMCredits;


    // Start is called before the first frame update
    void Start()
    {
        BMPressKey = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
