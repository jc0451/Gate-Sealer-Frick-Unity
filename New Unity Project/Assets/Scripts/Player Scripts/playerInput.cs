using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerInput : MonoBehaviour
{

    public GameObject[] spells;
    public float shootingDelay = 0.55f;
    public static float cooldownTimer = 0.6f;
    public static int currentspell;


    void Update()
    {



        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && Input.GetButton("Fire3") && cooldownTimer <= 0)
        {
            cooldownTimer = shootingDelay;
            currentspell = 0;

            Instantiate(spells[currentspell], transform.position, transform.rotation);


        }
        else if (Input.GetButton("Fire2") && Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            cooldownTimer = shootingDelay;
            currentspell = 1;

            Instantiate(spells[currentspell], transform.position, transform.rotation);

        }
    }

}