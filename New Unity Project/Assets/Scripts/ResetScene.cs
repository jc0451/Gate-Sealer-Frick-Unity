using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour {

    public string sceneName;
    

    void Start () {
		
	}
	
	
	void Update () {
       

        
            StartCoroutine(LoadScene());
        
	}

    IEnumerator LoadScene()
    {


        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(sceneName);
    }
}
