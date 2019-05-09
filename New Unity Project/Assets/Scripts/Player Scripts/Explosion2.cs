using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion2 : MonoBehaviour {

    public float time = 0.5f;
    public float currenttime;
    public int nr;
    public int childs;
    // Use this for initialization
    void Start () {
        currenttime = time;
        nr = 0;
        childs = transform.childCount;
    }
	
	// Update is called once per frame
	void Update () {
       
           
        currenttime -= Time.deltaTime;
        if (currenttime <= 0.0f && nr < childs)
         {
            transform.GetChild(nr).gameObject.SetActive(true);
            currenttime = time;
            nr+=1;
         }
        if (currenttime < -2f)
        {
            Destroy(gameObject);
        }
           
        
    }

}
