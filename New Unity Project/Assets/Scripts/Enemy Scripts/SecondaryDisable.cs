using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryDisable : MonoBehaviour {
    public float time = 0.5f;
    public float elapsed;
    bool off = false;
    // Use this for initialization
    void Start () {
        elapsed = time;
    }
	
	// Update is called once per frame
	void Update () {
        if (off ==true)
        {
            elapsed -= Time.deltaTime;
            if (elapsed <= 0.5f)
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
            if (elapsed <= 0.0f)
            {
                elapsed = time;
                
                transform.GetChild(0).gameObject.SetActive(true);
                off = false;

            }

        }


	}
    void disable()
    {
       
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        off = true;
    }
}
