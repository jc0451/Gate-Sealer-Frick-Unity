using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PenguinScript : MonoBehaviour
{
    public GameObject Bulletprefab;
    private float shootingDelay = 2f;
    private float cooldownTimer = 2.5f;
    public float maxHealth = 20;
    public float currentHealth;
    public float moveSpeed = 3;
    float roationspeed = 160f;
   //public GameObject deathAnimation;
    Vector2 randpos;
    private Material matRed;
    private Material matDefault;
    SpriteRenderer sr;


    private Transform Player;
    private Transform Player2;
    private float x;
    private float y;


    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Penguin");
        x = Random.Range(-12, 13);
        y = Random.Range(-8, 5);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        randpos = new Vector2(x, y);

        sr = GetComponent<SpriteRenderer>();
        matRed = Resources.Load("RedFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }


    void Update()
    {
        cooldownTimer -= Time.deltaTime;
       

        if (cooldownTimer <=0)
        {
            cooldownTimer = shootingDelay;
            GameObject bullet = (GameObject)Instantiate(Bulletprefab, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("Penguin");

        }
        transform.position = Vector2.MoveTowards(transform.position, randpos, Time.deltaTime * moveSpeed);

        if (currentHealth <= 0)
        {
            //Instantiate(deathAnimation, transform.position, transform.rotation);
            

            Destroy(gameObject);
        }

        if (Player == null && Player2 == null)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            GameObject go2 = GameObject.FindGameObjectWithTag("Player2");

            if (go != null && go2 !=null)
            {
                //Player = go.transform;
                Player2 = go2.transform;
            }
        }

        if (Player == null && Player2 == null)
            return;

        

       


    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerSpell")
        {
            sr.material = matRed;
            if (currentHealth == 1)
            {
                ScoreScript.ScoreValue1 += 50;
            }
            currentHealth--;

        }
        else if (currentHealth <= 0)
        {
            KillsItself();
        }
        else
        {
            Invoke("ResetMaterial", 0.3f);
        }



        if (col.gameObject.tag == "PlayerSpell2")
        {
            sr.material = matRed;
            if (currentHealth == 1)
            {
                ScoreScript2.ScoreValue2 += 50;
            }
            currentHealth--;


        }
        else if (currentHealth <= 0)
        {
            KillsItself();
        }
        else
        {
            Invoke("ResetMaterial", 0.3f);
        }

    }

    private void ResetMaterial()
    {
        sr.material = matDefault;
    }
    private void KillsItself()
    {
        Destroy(gameObject);
    }
}
