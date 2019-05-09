using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTick : MonoBehaviour {
    public float time = 0.5f;
    
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
