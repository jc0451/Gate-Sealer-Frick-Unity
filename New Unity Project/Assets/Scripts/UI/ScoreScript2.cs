using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript2 : MonoBehaviour {

    public static int ScoreValue2 = 0;
    Text Score;

    void Start()
    {

        Score = GetComponent<Text>();
    }


    void Update()
    {

        Score.text = "P2 Score: " + ScoreValue2;
    }
}
