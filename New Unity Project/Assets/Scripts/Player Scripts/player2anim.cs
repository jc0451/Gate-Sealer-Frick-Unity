using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2anim : MonoBehaviour {

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            anim.SetBool("clappingRight", true);
        }
        else
        {
            anim.SetBool("clappingRight", false);
        }



        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetBool("urfingRight", true);
        }
        else
        {
            anim.SetBool("urfingRight", false);
        }

        
    }
}
