using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour {
    Text inputs;
    int urf = 0;
    int clap = 0;
    int times = 0;
    public float time = 0.3f;
    public float currtime;
    public bool PlayerOne;
    // Use this for initialization
    void Start () {
        inputs = GetComponent<Text>();
        currtime = time;

    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerOne == true)
        {
            if (Player1.firstkey1 == true)
            {
                inputs.text = "urf";
                urf++;
                Player1.firstkey1 = false;
                times++;
            }
            if (Player1.firstkey2 == true)
            {
                inputs.text = "clap";
                clap++;
                Player1.firstkey2 = false;
                times++;
            }
            if (Player1.secondkey1 == true)
            {
                if (urf >= 1)
                {
                    inputs.text = "urf urf";
                }
                if (clap >= 1)
                {
                    inputs.text = "clap urf";
                }

                Player1.secondkey1 = false;
                times++;
            }
            if (Player1.secondkey2 == true)
            {
                if (urf >= 1)
                {
                    inputs.text = "urf clap";
                }
                if (clap >= 1)
                {
                    inputs.text = "clap clap";
                }
                Player1.secondkey2 = false;
                times++;
            }
            if (times >= 2)
            {
                currtime -= Time.deltaTime;
                if (currtime <= 0.0f)
                {
                    inputs.text = " ";
                    currtime = time;
                    urf = 0;
                    clap = 0;
                    times = 0;
                }


            }
        }
        if (PlayerOne == false)
        {
            if (Player2.firstkey1 == true)
            {
                inputs.text = "urf";
                urf++;
                Player2.firstkey1 = false;
                times++;
            }
            if (Player2.firstkey2 == true)
            {
                inputs.text = "clap";
                clap++;
                Player2.firstkey2 = false;
                times++;
            }
            if (Player2.secondkey1 == true)
            {
                if (urf >= 1)
                {
                    inputs.text = "urf urf";
                }
                if (clap >= 1)
                {
                    inputs.text = "clap urf";
                }

                Player2.secondkey1 = false;
                times++;
            }
            if (Player2.secondkey2 == true)
            {
                if (urf >= 1)
                {
                    inputs.text = "urf clap";
                }
                if (clap >= 1)
                {
                    inputs.text = "clap clap";
                }
                Player2.secondkey2 = false;
                times++;
            }
            if (times >= 2)
            {
                currtime -= Time.deltaTime;
                if (currtime <= 0.0f)
                {
                    inputs.text = " ";
                    currtime = time;
                    urf = 0;
                    clap = 0;
                    times = 0;
                }


            }
        }

    }
}
