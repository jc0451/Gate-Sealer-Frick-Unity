using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaGouls : MonoBehaviour
{

    public float maxHealth = 2;
    public float currentHealth;
    public GameObject[] ZigZagDirections1;
    
    
    public float moveSpeed = 3;
    private int currentposition = 0;
    void Start()
    {
        
        currentHealth = maxHealth;
        FindObjectOfType<AudioManager>().Play("Seagull");

    }
   
    void update ()
    {
        

        for (int i = 0; i < ZigZagDirections1.Length; i++)
        {
            transform.position = Vector2.MoveTowards(transform.position, ZigZagDirections1[i].transform.position, Time.deltaTime * moveSpeed);
        }



        if (currentHealth <= 0)
        {
            //Instantiate(deathAnimation, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
