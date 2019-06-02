using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryDisable : MonoBehaviour
{
    public float time = 16f;
    public float elapsed;
    public float disabletime = 36f;
    bool off = false;
    // Use this for initialization
    void Start()
    {
        elapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        disabletime -= Time.deltaTime;
        if (off == false)
        {
            elapsed += Time.deltaTime;
            if (elapsed <= 0.5f)
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
            if (elapsed >= 1.0f)
            {
                transform.GetChild(0).gameObject.SetActive(true);

            }
            if (elapsed >= time - 0.5f)
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
            if (elapsed >= time)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                off = true;
            }

        }
        if (disabletime <= 0f)
        {
            gameObject.SetActive(false);
        }

    }
}
 
