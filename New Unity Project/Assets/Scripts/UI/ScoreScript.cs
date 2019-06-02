using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int ScoreValue1 = 0;
    public Text P1Score;

	void Start ()
    {

        P1Score = GetComponent<Text>();
    }
	
	
	void Update ()
    {

        P1Score.text = "" + ScoreValue1;
    }
}
