using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {
    public float time = 0.5f;
    public float currenttime;
    public int nr;
    public int Strikes;
    public int struck;
    public int childs;
    // Use this for initialization
    void Start()
    {
        currenttime = time;
        struck = 0;
        
        childs = transform.childCount;
        nr = Random.Range(0, childs);
    }

    // Update is called once per frame
    void Update()
    {


        currenttime -= Time.deltaTime;
        if (currenttime <= 0.0f && struck <= Strikes)
        {
            transform.GetChild(nr).gameObject.SetActive(true);
            currenttime = time;
            nr = Random.Range(0, childs); ;
            struck++;
        }
        if (currenttime < -2f)
        {
            Destroy(gameObject);
        }


    }

}
