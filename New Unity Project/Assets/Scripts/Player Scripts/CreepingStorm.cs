using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepingStorm : MonoBehaviour {
    public GameObject Wave1;
    public GameObject Wave2;
    public GameObject Wave3;
    public GameObject Wave4;
    public int currwave = 1;
 
    public float time = 0.5f;
    public float currenttime;
    // Use this for initialization
    void Start () {
        Wave1.SetActive(true);
        currenttime = time;
    }
	
	// Update is called once per frame
	void Update () {
     
        currenttime -= Time.deltaTime;
        if (currenttime <= 0.0f)
        {
            if (currwave==2)
            {
                Wave2.SetActive(true);
            }
            if (currwave == 3)
            {
                Wave3.SetActive(true);
            }
            if (currwave == 4)
            {
                Wave4.SetActive(true);
            }
            if (currwave == 5)
            {
                Destroy(gameObject);
            }
            currwave++;
            currenttime = time;
        }

    }
   
}
