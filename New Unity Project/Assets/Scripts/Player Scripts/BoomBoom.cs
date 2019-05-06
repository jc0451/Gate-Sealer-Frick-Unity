using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBoom : MonoBehaviour {
    public GameObject Wave1;
    public GameObject Wave2;
    public GameObject Wave3;
    public GameObject Wave4;
    public GameObject Wave5;
    public GameObject Wave6;
    public GameObject Wave7;
    public GameObject Wave8;
    public GameObject Wave9;
    public GameObject Wave10;
    public GameObject Wave11;
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
                Wave5.SetActive(true);
            }
            if (currwave == 6)
            {
                Wave6.SetActive(true);
            }
            if (currwave == 7)
            {
                Wave7.SetActive(true);
            }
            if (currwave == 8)
            {
                Wave8.SetActive(true);
            }
            if (currwave == 9)
            {
                Wave9.SetActive(true);
            }
            if (currwave == 10)
            {
                Wave10.SetActive(true);
            }
            if (currwave == 11)
            {
                Wave11.SetActive(true);
            }
            if (currwave == 12)
            {
                
            }

            currwave++;
            currenttime = time;
        }

    }
   
}
