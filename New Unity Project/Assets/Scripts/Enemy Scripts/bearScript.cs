using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearScript : MonoBehaviour
{

    private float moveSpeed = 6f;
    public float maxHealth = 5;
    private float currentHealth;
    private Transform BearPoint;
    //public GameObject deathAnimation;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("GhostBear");
        BearPoint = GameObject.FindGameObjectWithTag("BearPoint").GetComponent<Transform>();
        currentHealth = maxHealth;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, BearPoint.position, moveSpeed * Time.deltaTime);

        if (currentHealth <= 0)
        {
            //Instantiate(deathAnimation, transform.position, transform.rotation);

            ScoreScript.ScoreValue1 += 100;
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerSpell")
        {
            if (currentHealth == 1)
            {
                ScoreScript.ScoreValue1 += 50;
            }
            currentHealth--;

        }
        else if (col.gameObject.tag == "Player")
        {
            ScoreScript.ScoreValue1 -= 25;
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "PlayerSpell2")
        {
            if (currentHealth == 1)
            {
                ScoreScript2.ScoreValue2 += 150;
            }
            currentHealth--;

        }
        else if (col.gameObject.tag == "Player2")
        {
            ScoreScript2.ScoreValue2 -= 25;
            Destroy(gameObject);
        }

    }

}
