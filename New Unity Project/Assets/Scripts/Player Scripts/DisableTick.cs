using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTick : MonoBehaviour {
    public float time = 0.5f;
    public float elapsed;
    // Use this for initialization
    void Start () {
        elapsed = time;
	}

    // Update is called once per frame
    void Update()
    {
        elapsed -= Time.deltaTime;
        if (elapsed <= 0.0f)
        {
            elapsed = time;
            gameObject.gameObject.SetActive(false);
            
        }
    }
}
