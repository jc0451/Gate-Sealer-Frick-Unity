using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {
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
    public GameObject Wave12;
    public GameObject Wave13;
    public GameObject Wave14;
    public GameObject Wave15;
    public int currwave = 1;

    public float time = 0.5f;
    public float currenttime;
    // Use this for initialization
    void Start()
    {
        Wave1.SetActive(true);
        currenttime = time;
    }

    // Update is called once per frame
    void Update()
    {

        currenttime -= Time.deltaTime;
        if (currenttime <= 0.0f)
        {
            switch (currwave)
            {
                case 2:
                    Wave2.SetActive(true);
                    break;
                case 3:
                    Wave3.SetActive(true);
                    break;
                case 4:
                    Wave4.SetActive(true);
                    break;
                case 5:
                    Wave5.SetActive(true);
                    break;
                case 6:
                    Wave6.SetActive(true);
                    break;
                case 7:
                    Wave7.SetActive(true);
                    break;
                case 8:
                    Wave8.SetActive(true);
                    break;
                case 9:
                    Wave9.SetActive(true);
                    break;
                case 10:
                    Wave10.SetActive(true);
                    break;
                case 11:
                    Wave11.SetActive(true);
                    break;
                case 12:
                    Wave12.SetActive(true);
                    break;
                case 13:
                    Wave13.SetActive(true);
                    break;
                case 14:
                    Wave14.SetActive(true);
                    break;
                case 15:
                    Wave15.SetActive(true);
                    break;
            }

            currwave++;
            currenttime = time;
        }

    }
}
