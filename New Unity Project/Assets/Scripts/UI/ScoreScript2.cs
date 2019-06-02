using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript2 : MonoBehaviour {

    public static int ScoreValue2 = 0;
    public Text P2Score;

    void Start()
    {

        P2Score = GetComponent<Text>();
    }


    void Update()
    {

        P2Score.text = "" + ScoreValue2;
    }
}
