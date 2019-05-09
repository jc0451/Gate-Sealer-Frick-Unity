using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBoom : MonoBehaviour {
    public GameObject Wave1;
    public GameObject Wave2;
    public GameObject Wave3;
    public int currwave = 1;
 
    public float time = 0.5f;
    public float currenttime;
    // Use this for initialization
    void Start () {
       
        currenttime = time;
    }
	
	// Update is called once per frame
	void Update () {
     
        currenttime -= Time.deltaTime;
        if (currenttime <= 0.0f)
        {
            if (currwave == 1)
            {
                Wave1.SetActive(true);
            }
            if (currwave==2)
            {
                Wave2.SetActive(true);
            }
            if (currwave == 3)
            {
                Wave3.SetActive(true);
            }
    

            currwave++;
            currenttime = time;
        }

    }
   
}
