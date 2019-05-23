using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static bool isPaused = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }






    }
    public void Resume()
    {
        
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Pause()

    {
        
        Time.timeScale = 0f;
        isPaused = true;
    }
}
