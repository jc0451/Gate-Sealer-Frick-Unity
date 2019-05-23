using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void PlayButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
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