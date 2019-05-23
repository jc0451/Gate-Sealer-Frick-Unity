using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreScene : MonoBehaviour {

    public void BackButton()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
