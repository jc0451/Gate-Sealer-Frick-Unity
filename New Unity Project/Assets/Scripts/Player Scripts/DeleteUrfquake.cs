﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteUrfquake : MonoBehaviour {
    public float time = 1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
