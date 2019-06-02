using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player1finalScore : MonoBehaviour {

    public static int ScorefinalValue1 = 0;
    public Text P1finalScore;
    
    void Start () {

        P1finalScore = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {

        ScorefinalValue1 = ScoreScript.ScoreValue1;

        P1finalScore.text = "Player1's Final score : " + ScorefinalValue1;

    }
}
