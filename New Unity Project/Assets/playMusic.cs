using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().Play("BattleMusic");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
