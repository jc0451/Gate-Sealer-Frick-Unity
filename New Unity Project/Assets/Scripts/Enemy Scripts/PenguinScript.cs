using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PenguinScript : MonoBehaviour
{
    public Transform floatingDamageP1;
    public Transform floatingDamageP2;
    public GameObject Bulletprefab;
    public GameObject rangedisc;
    public GameObject dieflame;
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
    public Animator anim;


    private Transform Player;
    private Transform Player2;
    private float x;
    private float y;
    public Rigidbody2D rb;
    Vector2 posit;
    float randstop;
    bool ready = false;
    float readycool = 2f;

    void Start()
    {
        
        x = Random.Range(-12f, 13f);
        y = Random.Range(-3f, 2f);
        //x = Random.Range(-4f, 5f);
       // y = Random.Range(-5f, -3f);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        randpos = new Vector2(x, y);
        cooldownTimer = shootingDelay;

        anim = GetComponent<Animator>();

       
        GameObject Stopdisc = (GameObject)Instantiate(rangedisc,new Vector3(x,y,0), Quaternion.identity);
        posit = transform.position;
        randstop = Random.Range(-5f, -1f);
        shootingDelay = Random.Range(shootingDelaymin, shootingDelaymax);

        sr = GetComponent<SpriteRenderer>();
        matRed = Resources.Load("RedFlash", typeof(Material)) as Material;
        matDefault = sr.material;


    }


    void Update()
    {
        readycool -= Time.deltaTime;
        if (readycool <= 0)
        {
            ready = true;
        }

        if(transform.position.y < randstop)
        {
            
            moveing++;
        }
        if (transform.position.x < -12f||transform.position.x>13f)
        {
            
            moveing++;
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
            Vector3 targ = randpos;
            targ.z = 0f;

            targ.x = targ.x - posit.x;
            targ.y = targ.y - posit.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg +90;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));



            rb.AddForce((randpos - posit).normalized * moveSpeed);
        }
        if (moveing >= 1)
        {
            cooldownTimer -= Time.deltaTime;
            rb.velocity = Vector3.zero;
            
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            anim.SetBool("walk", false);
            float angle = 0f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
           
            rb.angularVelocity = 0;

        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (ready == true)
        {
            if (col.gameObject.tag == "Penguin")
            {

                moveing++;

            }
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
        GameObject die = (GameObject)Instantiate(dieflame, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
