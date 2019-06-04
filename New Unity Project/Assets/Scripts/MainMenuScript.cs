using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    
    private int P1active = 0;
    private int P2active = 0;
    
    public Sprite[] BackgroundSprites;
    public Image backgroundImage;
    private float time;
    


    public static int currentBackground;
    public GameObject Panel;
    void Start()
    {
        currentBackground = 0;
        time = 5f;
    }
    void Update()
    {


        if (Input.GetKey(KeyCode.W))
        {
            currentBackground = 1;
            P1active = 1;
        }



        if (Input.GetKey(KeyCode.O))
        {
            currentBackground = 2;
            P2active = 1;
        }




        if (P1active == 1 && P2active == 1)
        {
            currentBackground = 3;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(true);
            time -= Time.deltaTime;
            if (time <= 3f)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }
            if (time <= 1f)
            {
                transform.GetChild(2).gameObject.SetActive(true);
            }
            if (time <= 0)
            {
                SceneManager.LoadScene("Main");
            }
            
           
        }
        

        

        backgroundImage.sprite = BackgroundSprites[currentBackground];

       

    }
    

}