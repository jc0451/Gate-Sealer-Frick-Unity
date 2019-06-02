using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player2finalScore : MonoBehaviour {

    public static int ScorefinalValue2 = 0;
    public Text P2finalScore;

    void Start()
    {

        P2finalScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        ScorefinalValue2 = ScoreScript2.ScoreValue2;
        P2finalScore.text = "Player2's Final score : " + ScorefinalValue2;

    }
}

