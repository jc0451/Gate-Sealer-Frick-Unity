using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCrack : MonoBehaviour {
    public GameObject crack;

	// Use this for initialization
	void Start () {
        GameObject crackinst = (GameObject)Instantiate(crack);
        crackinst.transform.position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
