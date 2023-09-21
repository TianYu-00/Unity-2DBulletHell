using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    private float timeBetweenSpawn;
    public float startTimeBetweenSpawn;

    private void Start()
    {
        timeBetweenSpawn = startTimeBetweenSpawn;
    }

    private void Update()
    {
        if (timeBetweenSpawn <= 0)
        {
            int randPos = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[randPos].position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
        }
        else {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
