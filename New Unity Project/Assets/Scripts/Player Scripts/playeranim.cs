using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeranim : MonoBehaviour {

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.W) )
        {
            anim.SetBool("IsTrigger", true);
        }
        else
        {
            anim.SetBool("IsTrigger", false);
        }



        if (Input.GetKey(KeyCode.E) )
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
	}
}
