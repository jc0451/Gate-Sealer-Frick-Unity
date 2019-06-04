using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static bool isPaused = false;
    public string sceneName;
    public static bool restart = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            StartCoroutine(LoadScene());
            restart = true;
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

        if (timerScript.timer >= 5f && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main"))
        {
            
                FindObjectOfType<AudioManager>().Play("CountingDown");

            
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
    IEnumerator LoadScene()
    {


        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
