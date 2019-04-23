using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAudio : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {

        FindObjectOfType<AudioManager>().Play("BackgroundAmbiance");

        FindObjectOfType<AudioManager>().Play("BackgroundMusic");

    }

    //IEnumerator Wait()
    //{

    //    yield return new WaitForSeconds(6.865f);

    //    FindObjectOfType<AudioManager>().Play("TitleTheme2");

    //}

    private void Update()
    {

       

        if (Input.GetKeyDown(KeyCode.Y))
        {

            FindObjectOfType<AudioManager>().StopMusic("BackgroundAmbiance");

            FindObjectOfType<AudioManager>().StopMusic("BackgroundMusic");

            SceneManager.LoadScene("MenuAdded");

        }

        if (Input.GetKeyDown(KeyCode.P))
        {

            FindObjectOfType<AudioManager>().StopMusic("BackgroundAmbiance");

            FindObjectOfType<AudioManager>().StopMusic("BackgroundMusic");

            SceneManager.LoadScene("Boss");

        }

    }
}
