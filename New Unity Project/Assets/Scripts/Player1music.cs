using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1music : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        FindObjectOfType<AudioManager>().Play("player1win");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
