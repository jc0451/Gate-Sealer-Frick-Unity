using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnTime : MonoBehaviour {
    public float timertime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timerScript.timer <= timertime)
        {
            gameObject.gameObject.SetActive(false);
        }
	}
}
