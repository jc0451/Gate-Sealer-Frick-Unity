using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PenguinScript : MonoBehaviour
{
    public Transform floatingDamageP1;
    public Transform floatingDamageP2;
    public GameObject Bulletprefab;
    public float shootingDelay = 2f;
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
        x = Random.Range(-12f, 13f);
        y = Random.Range(-8f, 5f);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        randpos = new Vector2(x, y);
        cooldownTimer = shootingDelay;

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
                DamagePopup.Create(floatingDamageP1, transform.position, 50);
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
                DamagePopup.Create(floatingDamageP2, transform.position, 50);
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
