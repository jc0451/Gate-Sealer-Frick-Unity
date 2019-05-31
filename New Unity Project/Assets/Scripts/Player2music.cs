using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2music : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().Play("player2win");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
