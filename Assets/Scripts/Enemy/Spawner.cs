using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float Intervalo = 2f;
    private Transform spawnPoint;
    public Tower TowerScript;
    public int SpawnNumber;
    // Start is called before the first frame update
    private void Start()

    {

        // Start spawning enemies
        spawnPoint = GetComponent<Transform>();

        InvokeRepeating("SpawnEnemy", 0f, Intervalo);
        TowerScript.Spawn1 = true; 
        TowerScript.Spawn2 = true;
        TowerScript.Spawn3 = true;

    }

    private void Update()
    {
        if(SpawnNumber == 1 && TowerScript.Spawn1 == false)
        {
            Destroy(gameObject);
        }
        if(SpawnNumber == 2 && TowerScript.Spawn2 == false)
        {
            Destroy(gameObject);
        }
        if(SpawnNumber == 3 && TowerScript.Spawn3 == false)
        {
            Destroy(gameObject);
        }
    }



    void SpawnEnemy()

    {

        //if (spawnPoints.Length == 0) return; // No spawn points available



        // Choose a random spawn point

        



        // Instantiate the enemy prefab at the spawn point

        Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity);

    }
}
