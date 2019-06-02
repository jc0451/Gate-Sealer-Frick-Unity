﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaGhouls2 : MonoBehaviour {

    private GameObject P1;
    private GameObject P2;
    public Animator anim;
    public GameObject dieflame;

    public Transform floatingDamageP1;
    public Transform floatingDamageP2;
    int rand1;
    int rand2;
    int randP;
    bool row1 = true;
    bool row2 = false;
    bool row3 = false;
    bool row4 = false;
    bool row5 = false;

    private float lx;
    private float rx;
    private float y1;
    private float y2;
    private float y3;
    private float y4;
    Vector2 randpos;
    Vector2 currpos;
    private int coin;

    public float maxHealth = 2;
    public float currentHealth;
    public float moveSpeed = 3;

    private Material matRed;
    private Material matDefault;
    SpriteRenderer sr;

    void Start () {
        P1 = GameObject.Find("Player1");
        P2 = GameObject.Find("Player2");
        rand1 = Random.Range(1, 6);
        rand2 = Random.Range(1, 8);
        randP = Random.Range(1, 3);
        coin = Random.Range(0, 2);
        lx = Random.Range(-12f, 1f);
        rx = Random.Range(0f, 13f);
        y1 = Random.Range(0f, 3f);
        y2 = Random.Range(-1f, 2f);
        y3 = Random.Range(-2f, 1f);
        y4 = Random.Range(-3f, 0f);
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
        matRed = Resources.Load("RedFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }
	
	// Update is called once per frame
	void Update () {
        if (row1 == true)
        {
            currpos = transform.position;
            if (coin == 0)
            {
                randpos = new Vector2(lx, y1);
                transform.position = Vector2.MoveTowards(transform.position, randpos, Time.deltaTime * moveSpeed);
                anim.SetBool("Left", true);
            }
            else if (coin == 1)
            {
                randpos = new Vector2(rx, y1);
                transform.position = Vector2.MoveTowards(transform.position, randpos, Time.deltaTime * moveSpeed);
                anim.SetBool("Left", false);
            }
            if(currpos == randpos)
            {
                row2 = true;
                lx = Random.Range(-12f, 1f);
                rx = Random.Range(0f, 13f);
                row1 = false;
            }
        }
        if (row2 == true)
        {
            currpos = transform.position;
            if (coin == 0)
            {
                randpos = new Vector2(rx, y2);
                transform.position = Vector2.MoveTowards(transform.position, randpos, Time.deltaTime * moveSpeed);
                anim.SetBool("Left", false);
            }
            else if (coin == 1)
            {
                randpos = new Vector2(lx, y2);
                transform.position = Vector2.MoveTowards(transform.position, randpos, Time.deltaTime * moveSpeed);
                anim.SetBool("Left", true);
            }
            if (currpos == randpos)
            {
                row3 = true;
                lx = Random.Range(-12f, 1f);
                rx = Random.Range(0f, 13f);
                row2 = false;
            }
        }
        if (row3 == true)
        {
            currpos = transform.position;
            if (coin == 0)
            {
                randpos = new Vector2(lx, y3);
                transform.position = Vector2.MoveTowards(transform.position, randpos, Time.deltaTime * moveSpeed);
                anim.SetBool("Left", true);
            }
            else if (coin == 1)
            {
                randpos = new Vector2(rx, y3);
                transform.position = Vector2.MoveTowards(transform.position, randpos, Time.deltaTime * moveSpeed);
                anim.SetBool("Left", false);
            }
            if (currpos == randpos)
            {
                row4 = true;
                lx = Random.Range(-12f, 1f);
                rx = Random.Range(0f, 13f);
                row3 = false;
            }
        }
        if (row4 == true)
        {
            currpos = transform.position;
            if (coin == 0)
            {
                randpos = new Vector2(rx, y4);
                transform.position = Vector2.MoveTowards(transform.position, randpos, Time.deltaTime * moveSpeed);
                anim.SetBool("Left", false);
            }
            else if (coin == 1)
            {
                randpos = new Vector2(lx, y4);
                transform.position = Vector2.MoveTowards(transform.position, randpos, Time.deltaTime * moveSpeed);
                anim.SetBool("Left", true);
            }
            if (currpos == randpos)
            {
                row5 = true;
                row4 = false;
            }
        }

        if (row5 == true)
        {
            if (randP == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, P1.transform.position, Time.deltaTime * moveSpeed);
                if (P1.transform.position.x < 0)
                {
                    anim.SetBool("Left", true);
                }
                else
                {
                    anim.SetBool("Left", false);
                }
            }
            if (randP == 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, P2.transform.position, Time.deltaTime * moveSpeed);
                if (P2.transform.position.x < 0)
                {
                    anim.SetBool("Left", true);
                }
                else
                {
                    anim.SetBool("Left", false);
                }
            }

        }
        if (currentHealth <= 0)
        {
           
            FindObjectOfType<AudioManager>().Play("Seagull");
            GameObject die = (GameObject)Instantiate(dieflame, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       
     
        if (col.gameObject.tag == "PlayerSpell" )
        {
            sr.material = matRed;
            if (currentHealth == 1)
            {
                ScoreScript.ScoreValue1 += 25;
                DamagePopup.Create(floatingDamageP1, transform.position, 25);
            }
            currentHealth--;

        }
        else if (col.gameObject.tag == "Player")
        {
            sr.material = matRed;
            FindObjectOfType<AudioManager>().Play("Seagull");
            GameObject die = (GameObject)Instantiate(dieflame, transform.position, transform.rotation);
            Destroy(gameObject);
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
                ScoreScript2.ScoreValue2 += 25;
                DamagePopup.Create(floatingDamageP2, transform.position, 25);
            }
            currentHealth--;

        }
        else if (col.gameObject.tag == "Player2")
        {
            sr.material = matRed;
            FindObjectOfType<AudioManager>().Play("Seagull");
            GameObject die = (GameObject)Instantiate(dieflame, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            Invoke("ResetMaterial", 0.3f);
        }

    }
    void ResetMaterial()
    {
        sr.material = matDefault;
    }
}
