using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearScript : MonoBehaviour
{

    private float moveSpeed = 6f;
    public float maxHealth = 2;
    public float currentHealth;
    private Transform Player;
    //public GameObject deathAnimation;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentHealth = maxHealth;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, moveSpeed * Time.deltaTime);

        if (currentHealth <= 0)
        {
            //Instantiate(deathAnimation, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }

    private void OntriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "playerSpell" || other.gameObject.tag == "Player")
        {
          currentHealth--;
        }
        
    }
}
