using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontdestoy : MonoBehaviour {

    void Awake()
    {
        GameObject.FindGameObjectWithTag("Score");

        if (ResetScene.backtomenu == true)
        {
            ScoreScript.ScoreValue1 = 0;
            ScoreScript2.ScoreValue2 = 0;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
