using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float Intervalo = 2f;
    private Transform spawnPoint;
    // Start is called before the first frame update
    private void Start()

    {

        // Start spawning enemies
        spawnPoint = GetComponent<Transform>();

        InvokeRepeating("SpawnEnemy", 0f, Intervalo);

    }



    void SpawnEnemy()

    {

        //if (spawnPoints.Length == 0) return; // No spawn points available



        // Choose a random spawn point

        



        // Instantiate the enemy prefab at the spawn point

        Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity);

    }
}
