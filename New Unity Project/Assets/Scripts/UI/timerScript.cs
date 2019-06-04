using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timerScript : MonoBehaviour {

    Text text;
    [SerializeField]
    public static float timer = 180;

	void Start ()
    {
        text = GetComponent<Text>();
	}



    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
            timer = 0;

        text.text = "Time left: " + Mathf.Round(timer);

        if (Input.GetKeyDown(KeyCode.V))
        {
            timer = 180;
        }

    }
}
