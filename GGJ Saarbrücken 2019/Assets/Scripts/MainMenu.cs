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
    public GameObject GOCat;
    public Transform TrCatSpawn;
    GameObject GOSpawendcat;
    public GameObject GOPressAnyTeyt;
    public GameObject GOHowtoCat;

    //TODO - Press any Key

    // Start is called before the first frame update
    void Start()
    {
        BMPressKey = true;
        StartCoroutine(AnyKey(1));
        
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
                SpawnCat();
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

    void SpawnCat()
    {
        if (!GOSpawendcat) {
            GOSpawendcat = Instantiate(GOCat, TrCatSpawn);
            GOSpawendcat.GetComponent<Cat_Enconuter>().GOCatSpawn = gameObject;
            GOSpawendcat.GetComponent<Cat_Enconuter>().BSpawnedRight = true;
            GOSpawendcat.GetComponent<Cat_Enconuter>().V2Destination = new Vector2(8, -1);
        }
        StartCoroutine(CatTutorial(1.5f));
    }

    private IEnumerator CatTutorial(float secs1)
    {
        yield return new WaitForSeconds(secs1);
        GOHowtoCat.GetComponent<SpriteRenderer>().enabled = true;
    }

    private IEnumerator AnyKey(float secs)
    {
        while (BMPressKey) { 
            yield return new WaitForSeconds(secs);
            if (BMPressKey && !GOPressAnyTeyt.GetComponent<SpriteRenderer>().enabled)
            {
                GOPressAnyTeyt.GetComponent<SpriteRenderer>().enabled = true;
            } else
            {
                GOPressAnyTeyt.GetComponent<SpriteRenderer>().enabled = false;
            }
    }
    }
}
