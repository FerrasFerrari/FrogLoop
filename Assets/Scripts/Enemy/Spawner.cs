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
    public Trigger TriggerScript;

    // Start is called before the first frame update
    private void Start()

    {

        // Start spawning enemies
        spawnPoint = GetComponent<Transform>();

        InvokeRepeating("SpawnEnemy", 0f, Intervalo);
        TowerScript.Spawn1 = true; 
        TowerScript.Spawn2 = true;
        TowerScript.Spawn3 = true;
        TriggerScript.PodeSpawnar1 = false;
        TriggerScript.PodeSpawnar2 = false;
        TriggerScript.PodeSpawnar3 = false;

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
        if(TriggerScript.PodeSpawnar1 == true && SpawnNumber == 1)
        {
            Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity);
        }
        if (TriggerScript.PodeSpawnar2 == true && SpawnNumber == 2)
        {
            Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity);
        }
        if (TriggerScript.PodeSpawnar3 == true && SpawnNumber == 3)
        {
            Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
