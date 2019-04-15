using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToPlayer : MonoBehaviour {

    private Vector2 target;
    private Vector2 position;
    public float speed;
    public int health = 1;
    private float direction;
    private float time = 0;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("PlayerCharacter");
        target = player.transform.position;
        position = gameObject.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (health <= 0)
        {
            Destroy(gameObject);
            ScoreScript.ScoreValue += 1;
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "PlayerSpell")
        {
          
            health--;
        }
    }
}
