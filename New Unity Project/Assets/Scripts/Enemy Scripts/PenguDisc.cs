using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguDisc : MonoBehaviour {
    public float time = 3.5f;
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            
           Destroy(gameObject);
        }
    }
}
