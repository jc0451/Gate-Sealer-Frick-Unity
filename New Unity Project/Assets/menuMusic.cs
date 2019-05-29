using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuMusic : MonoBehaviour
{


    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("mainMenu"))
        {
            FindObjectOfType<AudioManager>().Play("MainMenu");
        }
        
            
    }

}