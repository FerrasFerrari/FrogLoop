
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    public float timeToSpawn = 2;
    private float spawnTimer;
    private int nTrys = 0;
    [HideInInspector] public int enemyCount = 0;

    public Camera sceneCamera;
    public GameObject enemyToSpawn;
    public Transform minSpawn, maxSpawn;
    public LayerMask groundMask;

    void Start()
    {
        spawnTimer = timeToSpawn;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            spawnTimer = timeToSpawn;

            Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation);
            enemyCount++;
        }
        transform.position = sceneCamera.transform.position;
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;

        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);
            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }
            else
            {
                spawnPoint.x = minSpawn.position.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);
            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.y = maxSpawn.position.y;
            }
            else
            {
                spawnPoint.y = minSpawn.position.y;
            }
        }

        if(Physics2D.OverlapPoint(spawnPoint, groundMask) != null){
            nTrys = 0;
            return spawnPoint;
        }else{
            nTrys++;
            if(nTrys >= 10){
                return new Vector3(0, 0, 0);
            }
            return SelectSpawnPoint();
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(minSpawn.position, 1);
        Gizmos.DrawWireSphere(maxSpawn.position, 1);
    }
}
