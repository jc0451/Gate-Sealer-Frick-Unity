using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed;
    Vector2 position;
    Vector2 limit;
    
    // Use this for initialization
    void Start () {
        rb.velocity = new Vector2(0.0f, speed);
        limit = new Vector2 (0.0f, 4.0f);


    }
	
	// Update is called once per frame
	void Update () {
        position = gameObject.transform.position;
        if (limit.y <= position.y)
        {
            Destroy(gameObject);
        }
        
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Penguin")
        {
            Destroy(gameObject);
        }
    }
}
