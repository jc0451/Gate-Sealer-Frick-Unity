using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;
    private float startTime;
    public SpriteRenderer sprite;
    public bool timer = false;
    public float timertime;
    private bool lever=false;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
    }
	void timestart()
    {
        startTime = Time.time;
    }
	// Update is called once per frame
	void Update () {
        if (timer == false)
        {
            float t = (Time.time - startTime) / duration;
            sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
        }
        else if (timerScript.timer <= timertime && timer==true)
        {
            if (lever == false) {
                timestart();
                lever = true;
            }
           
            float t = (Time.time - startTime) / duration;
            sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
        }
    }
}
