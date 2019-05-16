using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private Vector2 target;
    //private Vector2 position;
    float moveSpeed = 8f;
    float deleteTime = 10f;
    Rigidbody2D rb;
  
    private int coin;
    Vector2 direction;
    public GameObject P1;
    public GameObject P2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
       P1 = GameObject.Find("Player1");
       P2 = GameObject.Find("Player2");
        coin = Random.Range(0, 2);
     
        if (coin == 1)
        {
            direction = (P1.transform.position - transform.position).normalized * moveSpeed;
        }
        else if (coin == 0)
        {
            direction = (P2.transform.position - transform.position).normalized * moveSpeed;
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
        //Vector3 pos = transform.position;
        //Vector3 Direction = new Vector3(0, moveSpeed * Time.deltaTime);
        //pos += transform.rotation * Direction;
        //transform.position = pos;

        deleteTime -= Time.deltaTime;

        if (deleteTime <= 0)
        {
            Destroy(gameObject);
        }
    }

}
