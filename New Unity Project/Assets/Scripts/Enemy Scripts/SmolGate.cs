using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmolGate : MonoBehaviour {
    private float stagetime = 36f;
    private int cap = 5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        stagetime -= Time.deltaTime;
        if (stagetime <= 0 && cap == 5)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            stagetime = 36f;
            cap--;

        }
        if (stagetime <= 0 && cap == 4)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(true);
            stagetime = 36f;
            cap--;

        }
        if (stagetime <= 0 && cap == 3)
        {
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(true);
            stagetime = 36f;
            cap--;

        }
        if (stagetime <= 0 && cap == 2)
        {
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);
            transform.GetChild(6).gameObject.SetActive(true);
            transform.GetChild(7).gameObject.SetActive(true);
            stagetime = 36f;
            cap--;

        }
   

    }
}
