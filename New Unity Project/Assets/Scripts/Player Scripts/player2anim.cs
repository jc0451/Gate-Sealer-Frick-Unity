using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2anim : MonoBehaviour {

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            anim.SetBool("IsTrigger", true);
        }
        else
        {
            anim.SetBool("IsTrigger", false);
        }



        if (Input.GetKey(KeyCode.P))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
