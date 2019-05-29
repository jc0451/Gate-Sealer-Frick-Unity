using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertarget : MonoBehaviour {

    Transform player;
    float roationspeed = 160f;

    void Start()
    {

    }


    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Player");

            if (go != null)
            {
                player = go.transform;
            }
        }

        if (player == null)
            return;

        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        float z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        Quaternion rotation = Quaternion.Euler(0, 0, z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, roationspeed * Time.deltaTime);
    }
}

