using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playeranim : MonoBehaviour {

    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {


        if (Player1.stun1 == false)
        {
            anim.SetBool("Stunned", false);
        }
        else 
        {
            anim.SetBool("Stunned", true);
        }

            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetBool("clappingleft", true);
            }
            else
            {
                anim.SetBool("clappingleft", false);
            }



            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("urfingleft", true);
            }
            else
            {
                anim.SetBool("urfingleft", false);
            }
        
        
        
    }

}
