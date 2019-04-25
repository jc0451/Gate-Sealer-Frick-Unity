using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearScript : MonoBehaviour
{

    private float moveSpeed = 6f;
    public float maxHealth = 2;
    public float currentHealth;
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
            ScoreScript.ScoreValue += 20;
            Destroy(gameObject);
        }
    }

    private void OntriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerSpell")
        {
            currentHealth--;
        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        
    }
}
