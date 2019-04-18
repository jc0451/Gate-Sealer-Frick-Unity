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
    int index;



    private Transform Player;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        index = Random.Range(0, positions.Length);
        stopPositions = positions[index];
        //System.Random rand = new System.Random();
        //int index = rand.Next(positions.Length);
    }


    void Update()
    {
        cooldownTimer -= Time.deltaTime;
       

        if (cooldownTimer <=0)
        {
            cooldownTimer = shootingDelay;
            GameObject bullet = (GameObject)Instantiate(Bulletprefab, transform.position, transform.rotation);
            
        }
        transform.position = Vector2.MoveTowards(transform.position, positions[index].transform.position, Time.deltaTime * moveSpeed);
        if (currentHealth <= 0)
        {
            //Instantiate(deathAnimation, transform.position, transform.rotation);

            Destroy(gameObject);
        }

        if (Player == null)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Player");

            if (go != null)
            {
                Player = go.transform;
            }
        }

        if (Player == null)
            return;

        Vector3 direction = Player.position - transform.position;
        direction.Normalize();
        float z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        Quaternion rotation = Quaternion.Euler(0, 0, z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, roationspeed * Time.deltaTime);


    }

    private void OntriggerEnter2D()
    {
        currentHealth--;
    }

}
