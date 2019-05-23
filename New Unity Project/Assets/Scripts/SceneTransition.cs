using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public Animator transision;
    public string sceneName;
    public string sceneName2;

    void Start()
    {

    }


    void Update()
    {
        if (timerScript.timer == 0 && ScoreScript.ScoreValue1 > ScoreScript2.ScoreValue2)
        {
            StartCoroutine(LoadScene());
        }
        else if (timerScript.timer == 0 && ScoreScript.ScoreValue1 < ScoreScript2.ScoreValue2)
        {
            StartCoroutine(LoadScene2());
        }
    }

    IEnumerator LoadScene()
    {
        

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator LoadScene2()
    {
        

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName2);
    }
}
