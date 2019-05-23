using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PenguinScript : MonoBehaviour
{
    public Transform floatingDamageP1;
    public Transform floatingDamageP2;
    public GameObject Bulletprefab;
    public GameObject rangedisc;
    public float shootingDelaymax = 2f;
    public float shootingDelaymin = 2f;
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
    public int moveing;


    private Transform Player;
    private Transform Player2;
    private float x;
    private float y;
    public Rigidbody2D rb;
    Vector2 posit;
    float randstop;

    void Start()
    {

        x = Random.Range(-12f, 13f);
        y = Random.Range(-8f, 0f);
        //x = Random.Range(-4f, 5f);
       // y = Random.Range(-5f, -3f);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        randpos = new Vector2(x, y);
        cooldownTimer = shootingDelay;

        sr = GetComponent<SpriteRenderer>();
        matRed = Resources.Load("RedFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        GameObject Stopdisc = (GameObject)Instantiate(rangedisc,new Vector3(x,y,0), Quaternion.identity);
        posit = transform.position;
        randstop = Random.Range(-5f, -1f);
        shootingDelay = Random.Range(shootingDelaymin, shootingDelaymax);
    }


    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if(transform.position.y < randstop)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
        }
        if (transform.position.x < -12f||transform.position.x>13f)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
        }
        if (cooldownTimer <= 0)
        {
            shootingDelay = Random.Range(shootingDelaymin, shootingDelaymax);
            cooldownTimer = shootingDelay;
            GameObject bullet = (GameObject)Instantiate(Bulletprefab, transform.position, transform.rotation);


        }
        if (moveing == 0)
        {
            //transform.position = Vector2.MoveTowards(transform.position, randpos, Time.deltaTime * moveSpeed);



            rb.AddForce((randpos - posit).normalized * moveSpeed);
        }
        if (moveing >= 1)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;

        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PenguinPoint")
        {
            moveing =1;
            rb.velocity = Vector3.zero;
            rb.angularVelocity =0;

        }


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
        FindObjectOfType<AudioManager>().Play("Penguin");
        Destroy(gameObject);
    }
}
