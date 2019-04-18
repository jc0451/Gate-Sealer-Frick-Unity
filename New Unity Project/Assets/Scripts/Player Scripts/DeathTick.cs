using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTick : MonoBehaviour {
    public float time = 0.5f;
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
