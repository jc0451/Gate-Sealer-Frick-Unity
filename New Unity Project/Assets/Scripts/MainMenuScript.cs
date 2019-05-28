using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private int P1active = 0;
    private int P2active = 0;

    public Sprite[] BackgroundSprites;
    public Image backgroundImage;

    public static int currentBackground;

    void Start()
    {
        currentBackground = 0;
    }
    void Update()
    {


        if (Input.GetKey(KeyCode.W))
        {
            currentBackground = 1;
            P1active = 1;
        }



        if (Input.GetKey(KeyCode.O))
        {
            currentBackground = 2;
            P2active = 1;
        }




        if (P1active == 1 && P2active == 1)
        {
            currentBackground = 3;
            SceneManager.LoadScene("Main");
        }

        backgroundImage.sprite = BackgroundSprites[currentBackground];

    }


    public void HighScoreButton()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

}