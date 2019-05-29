using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public static float time1 = 0.5f;
    public static float time2 = 0.5f;
    public static float time0 = 1f;
    public float amount = 1.0f;
    public static bool shake1 = false;
    public static bool shake2 = false;
    public static bool shakescreen = false;
    public int setting=0;
    Vector3 startingPos;
    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (setting == 1)
        {
            if (shake1 == true)
            {
                time1 -= Time.deltaTime;
                transform.position = Random.insideUnitCircle * amount;
                if (time1 <= 0)
                {
                    shake1 = false;
                    time1 = 0.5f;
                    transform.position = startingPos;


                }

            }
        }
        else if (setting == 2)
        {
            if (shake2 == true)
            {
                time2 -= Time.deltaTime;
                transform.position = Random.insideUnitCircle * amount;
                if (time2 <= 0)
                {
                    shake2 = false;
                    time2 = 0.5f;
                    transform.position = startingPos;


                }

            }
        }
        else if(setting == 0)
        {
            
            if (shakescreen == true)
            {
                time0 -= Time.deltaTime;
               // Vector3 temp = new Vector3(0, 0, -8);
                transform.position = Random.insideUnitCircle * amount;
              //  transform.position += temp;
                if (time0 <= 0)
                {
                    shakescreen = false;
                    transform.position = startingPos;



                }

            }
        }



    }
}