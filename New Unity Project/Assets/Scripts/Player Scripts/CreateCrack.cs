using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCrack : MonoBehaviour {
    public GameObject crack;
    Vector2 pos;
    float time = 0.2f;
    float angle;
	// Use this for initialization
	void Start () {
        pos = transform.position;
        pos.y -= 1;
        angle = Random.Range(-10f, 10f);
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            GameObject crackinst = (GameObject)Instantiate(crack);

            crackinst.transform.position = pos;
            crackinst.transform.localScale = transform.localScale;
            crackinst.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            time = 99;
        }
		
	}
}
