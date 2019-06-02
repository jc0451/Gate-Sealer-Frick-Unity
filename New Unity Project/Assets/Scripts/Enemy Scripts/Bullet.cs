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
        if (coin == 1)
        {

            direction = P1.transform.position;
        }
        else if (coin == 0)
        {
            direction = P2.transform.position;
        }
        direction.y -=2f;

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
      
        Vector2 posit = transform.position;
        Vector3 targ = direction;
        targ.z = 0f;
        
        targ.x = targ.x - posit.x;
        targ.y = targ.y - posit.y;

        rb.velocity = (direction - posit).normalized * moveSpeed;
        if (posit == direction)
        {
            Destroy(gameObject);
        }

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //rb.AddForce((direction - posit).normalized * moveSpeed);
        deleteTime -= Time.deltaTime;

        if (deleteTime <= 0)
        {
            Destroy(gameObject);
        }
    }

}
