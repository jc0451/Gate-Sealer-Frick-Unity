using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour {

    public GameObject Enemy;
    public GameObject Spawnflame;
    public float spawndelay = 5.0f;
    public float timeactual = 5.0f;
    private float stagetime = 36f;
    public int pengucap = 5;
    private GameObject[] getCount;
    private int count= 0;


    void Start()
    {
        timeactual = spawndelay;
        pengucap -= 1;

    }

    void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("Penguin");
        count = getCount.Length;
        stagetime -= Time.deltaTime;
        if (stagetime <= 0)
        {
            spawndelay = spawndelay - 0.5f;
            stagetime = 36f;


        }
        if (count <= pengucap)
        {
            timeactual -= Time.deltaTime;

            if (timeactual <= 0.0f)
            {
                    SpawnEnemy();
                    
                    timeactual = spawndelay;
            }
            
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
