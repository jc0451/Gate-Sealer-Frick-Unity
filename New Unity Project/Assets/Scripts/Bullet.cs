using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 target;
    private Vector2 position;
    float moveSpeed = 8f;
    float deleteTime = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }


    }
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 Direction = new Vector3(0, moveSpeed * Time.deltaTime);
        pos += transform.rotation * Direction;
        transform.position = pos;

        deleteTime -= Time.deltaTime;

        if (deleteTime <= 0)
        {
            Destroy(gameObject);
        }
    }

}
