using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour {

    public string sceneName;
    public static bool backtomenu = false;

    void Start () {
		
	}
	
	
	void Update () {
       

        
            StartCoroutine(LoadScene());
        
	}

    IEnumerator LoadScene()
    {
        timerScript.timer = 180;
        backtomenu = true;
        GameControl.restart = true;
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(sceneName);
    }
}
