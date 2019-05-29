using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearScript : MonoBehaviour
{
    public Transform floatingDamageP1;
    public Transform floatingDamageP2;
    public GameObject dieflame;
    public float moveSpeed = 1f;
    public float maxHealth = 6;
    private float currentHealth;
    private Transform BearPoint;
    //public GameObject deathAnimation;
    private Material matRed;
    private Material matDefault;
    SpriteRenderer sr;


    void Start()
    {
      
        FindObjectOfType<AudioManager>().Play("GhostBearSpawn");
        BearPoint = GameObject.FindGameObjectWithTag("BearPoint").GetComponent<Transform>();
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
        matRed = Resources.Load("RedFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, BearPoint.position, moveSpeed * Time.deltaTime);
        if (currentHealth == 0)
        {
            FindObjectOfType<AudioManager>().Play("BearDie");
            CommitDie();
        }
        if (transform.position.y <=-9)
        {
            FindObjectOfType<AudioManager>().Play("BearAttack");
            GameObject die = (GameObject)Instantiate(dieflame, transform.position, transform.rotation);
            Shake.shakescreen = true;
            Shake.time0 = 1f;
            Player1.stun1 = true;
            Player2.stun2 = true;
            CommitDie();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerSpell")
        {
            sr.material = matRed;
            if (currentHealth == 1)
            {
                ScoreScript.ScoreValue1 += 100;
                DamagePopup.Create(floatingDamageP1, transform.position, 100);
            }
            currentHealth--;

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
                ScoreScript2.ScoreValue2 += 100;
                DamagePopup.Create(floatingDamageP2, transform.position, 100);
            }
            currentHealth--;

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

    private void CommitDie()
    {
        Destroy(gameObject);
    }
}
