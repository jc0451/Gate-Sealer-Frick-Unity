using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaGhouls2 : MonoBehaviour {
    public GameObject R1N1;
    public GameObject R1N2;
    public GameObject R1N3;
    public GameObject R1N4;
    public GameObject R1N5;
    public GameObject R2N1;
    public GameObject R2N2;
    public GameObject R2N3;
    public GameObject R2N4;
    public GameObject R2N5;
    public GameObject R2N6;
    public GameObject R2N7;

    public GameObject P1;
    public GameObject P2;

    int rand1;
    int rand2;
    int randP;
    bool row1 = true;
    bool row2 = false;
    bool row3 = false;

    public float maxHealth = 2;
    public float currentHealth;
    public float moveSpeed = 3;
    // Use this for initialization
    void Start () {
       
        rand1 = Random.Range(1, 6);
        rand2 = Random.Range(1, 8);
        randP = Random.Range(1, 3);
    }
	
	// Update is called once per frame
	void Update () {
        if (row1 == true)
        {
            if (rand1 == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, R1N1.transform.position, Time.deltaTime * moveSpeed);
               
            }
            if (rand1 == 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, R1N2.transform.position, Time.deltaTime * moveSpeed);
               
            }
            if (rand1 == 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, R1N3.transform.position, Time.deltaTime * moveSpeed);
               
            }
            if (rand1 == 4)
            {
                transform.position = Vector2.MoveTowards(transform.position, R1N4.transform.position, Time.deltaTime * moveSpeed);
               
            }
            if (rand1 == 5)
            {
                transform.position = Vector2.MoveTowards(transform.position, R1N5.transform.position, Time.deltaTime * moveSpeed);
               
            }
        }
        if (row2 == true)
        {
            if (rand2 == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, R2N1.transform.position, Time.deltaTime * moveSpeed);
               
            }
            if (rand2 == 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, R2N2.transform.position, Time.deltaTime * moveSpeed);
                
            }
            if (rand2 == 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, R2N3.transform.position, Time.deltaTime * moveSpeed);
                
            }
            if (rand2 == 4)
            {
                transform.position = Vector2.MoveTowards(transform.position, R2N4.transform.position, Time.deltaTime * moveSpeed);
               
            }
            if (rand2 == 5)
            {
                transform.position = Vector2.MoveTowards(transform.position, R2N5.transform.position, Time.deltaTime * moveSpeed);
                
            }
            if (rand2 == 6)
            {
                transform.position = Vector2.MoveTowards(transform.position, R2N6.transform.position, Time.deltaTime * moveSpeed);
                
            }
            if (rand2 == 7)
            {
                transform.position = Vector2.MoveTowards(transform.position, R2N7.transform.position, Time.deltaTime * moveSpeed);
               
            }
        }
        if (row3 == true)
        {
            if (randP == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, P1.transform.position, Time.deltaTime * moveSpeed);
            }
            if (randP == 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, P2.transform.position, Time.deltaTime * moveSpeed);
            }

        }
        if (currentHealth <= 0)
        {
            //Instantiate(deathAnimation, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       
        if(col.gameObject.tag == "GullNodes1")
        {
            row1 = false;
            row2 = true;
            
           
        }
        if(col.gameObject.tag == "GullNodes2")
        {
            row2 = false;
            row3 = true;
        }
        if (col.gameObject.tag == "PlayerSpell" )
        {
            if (currentHealth == 1)
            {
                ScoreScript.ScoreValue1 += 25;
            }
            currentHealth--;

        }
        else if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "PlayerSpell2")
        {
            if (currentHealth == 1)
            {
                ScoreScript2.ScoreValue2 += 25;
            }
            currentHealth--;

        }
        else if (col.gameObject.tag == "Player2")
        {
            Destroy(gameObject);
        }

    }
}
