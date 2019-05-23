using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaySpawner : MonoBehaviour {

    public GameObject Enemy;
    public GameObject Spawnflame;
    public float spawndelay = 5.0f;
    public int maxspawn = 1;
    private int spawned = 0;
    public float timeactual = 5.0f;
    private float stagetime = 36f;
    private int cap = 5;



    void Start()
    {
        timeactual = spawndelay;

    }

    void Update()
    {
        stagetime -= Time.deltaTime;
        if (stagetime <= 0 && cap > 0)
        {
            spawndelay = spawndelay - 0.5f;
            stagetime = 36f;
            cap--;

        }
        if (spawned < maxspawn)
        {
            timeactual -= Time.deltaTime;

            if (timeactual <= 0.0f)
            {
                SpawnEnemy();
                spawned++;
                timeactual = spawndelay;
            }
        }
        else if (spawned >= maxspawn)
        {
            spawned = 0;
            SendMessageUpwards("disable");
        }

        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            spawned = 0;
        }


    }
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
        GameObject anEnemy = (GameObject)Instantiate(Enemy);
        GameObject flame = (GameObject)Instantiate(Spawnflame);
        anEnemy.transform.position = gameObject.transform.position;
        flame.transform.position = gameObject.transform.position;
        // anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x / 2), max.y);



    }
}
