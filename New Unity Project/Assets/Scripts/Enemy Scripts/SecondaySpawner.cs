using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaySpawner : MonoBehaviour {

    public GameObject Enemy;
    public GameObject Spawnflame;
    public float spawndelay = 5.0f;
    public float timeactual = 5.0f;



    void Start()
    {
        timeactual = spawndelay;

    }

    void Update()
    {
       
            timeactual -= Time.deltaTime;

            if (timeactual <= 0.0f)
            {
                SpawnEnemy();
               
                timeactual = spawndelay;
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
