using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PenguinScript : MonoBehaviour
{
    public GameObject Bulletprefab;
    private float shootingDelay = 2f;
    private float cooldownTimer = 2.5f;
    public float maxHealth = 2;
    public float currentHealth;
    public GameObject[] positions;
    public float moveSpeed = 3;
    float roationspeed = 160f;
    GameObject stopPositions;
   //public GameObject deathAnimation;
    private int index;



    private Transform Player;
    private Transform Player2;


    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Penguin");
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        index = Random.Range(0, positions.Length);
        stopPositions = positions[index];
       
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
        transform.position = Vector2.MoveTowards(transform.position, positions[index].transform.position, Time.deltaTime * moveSpeed);
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

        

        Vector3 direction = Player.position - transform.position;
        direction.Normalize();
        float z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        Quaternion rotation = Quaternion.Euler(0, 0, z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, roationspeed * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerSpell" || col.gameObject.tag == "Player")
        {
            if (currentHealth == 1)
            {
                ScoreScript.ScoreValue1 += 50;
            }
            currentHealth--;
           
        }
        if (col.gameObject.tag == "PlayerSpell2" || col.gameObject.tag == "Player")
        {
            if (currentHealth == 1)
            {
                ScoreScript2.ScoreValue2 += 50;
            }
            currentHealth--;

        }

    }

}
