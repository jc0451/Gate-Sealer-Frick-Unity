using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int enemiesPerWave;
    public GameObject Enemy;
}

public class SpawnerScriptV2 : MonoBehaviour {

    public Wave[] Waves;
    public Transform[] spawnPoints;
    public float TimeBetweenEnemies = 2f;

    private int totalEnemiesInThisWave;
    private int enemiesLeft;
    private int enemiesSpawned;

    private int currentWave;
    private int totalWaves;

	void Start ()
    {
        currentWave = 0;
        totalWaves = Waves.Length -1;

        StartNextWave();

	}

    void StartNextWave()
    {
        currentWave++;

        if (currentWave > totalWaves)
        {
            return;
        }
        totalEnemiesInThisWave = Waves[currentWave].enemiesPerWave;
        enemiesLeft = 0;
        enemiesSpawned = 0;

        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies()
    {
        GameObject enemy = Waves[currentWave].Enemy;
        while (enemiesSpawned < totalEnemiesInThisWave)
        {
            enemiesSpawned++;
            enemiesLeft++;

            int spawnIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            yield return new WaitForSeconds(TimeBetweenEnemies);

        }
        yield return null;
    }

    public void EnemiesDefeated()
    {
        enemiesLeft--;

        if (enemiesLeft== 0 && enemiesSpawned == totalEnemiesInThisWave)
        {
            StartNextWave();
        }
    }
    
}
