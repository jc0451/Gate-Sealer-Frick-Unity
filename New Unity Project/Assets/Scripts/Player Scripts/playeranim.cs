using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playeranim : MonoBehaviour {

    private Animator anim;
    public Slider stunMeter;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {


        if (stunMeter.value == 5)
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
