using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearScript : MonoBehaviour
{

    private float moveSpeed = 6f;
    public float maxHealth = 2;
    private float currentHealth=2;
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

   
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerSpell" || col.gameObject.tag == "Player")
        {
            if (currentHealth == 1)
            {
                ScoreScript.ScoreValue1 += 150;
            }
            currentHealth--;

        }
        if (col.gameObject.tag == "PlayerSpell2" || col.gameObject.tag == "Player")
        {
            if (currentHealth == 1)
            {
                ScoreScript2.ScoreValue2 += 150;
            }
            currentHealth--;

        }

    }

}
