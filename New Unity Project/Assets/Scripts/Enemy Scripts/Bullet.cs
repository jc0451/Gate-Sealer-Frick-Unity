using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private Vector2 target;
    //private Vector2 position;
    public float moveSpeed = 8f;
    public float deleteTime = 10f;
    Rigidbody2D rb;
    float roationspeed = 160;
    private int coin;
    Vector2 direction;
    Transform target;
    public GameObject P1;
    public GameObject P2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        P1 = GameObject.Find("Player1");
        P2 = GameObject.Find("Player2");
        coin = Random.Range(0, 2);

    }

    void movetowards ()
    {
        

        if (coin == 1)
        {

            direction = new Vector2(P1.transform.position.x, P1.transform.position.y).normalized * moveSpeed;
            
            float z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
            Quaternion rotation = Quaternion.Euler(0, 0, z);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, roationspeed * Time.deltaTime);
            
        }
        else if (coin == 0)
        {

            direction = new Vector2(P2.transform.position.x, P2.transform.position.y).normalized * moveSpeed;
            
            float z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
            Quaternion rotation = Quaternion.Euler(0, 0, z);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, roationspeed * Time.deltaTime);
           
        }
    }
     
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag == "Player2")
        {
           
            Destroy(gameObject);
        }


    }
    void Update()
    {
        rb.velocity = new Vector2(direction.x, direction.y);

        movetowards();
        deleteTime -= Time.deltaTime;

        if (deleteTime <= 0)
        {
            Destroy(gameObject);
        }
    }

}
