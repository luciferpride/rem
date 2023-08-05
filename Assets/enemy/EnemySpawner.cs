using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 5; // Set to 5 to spawn only 5 enemies
    public float spawnDelay = 1f;
    public float spawnRadius = 10f;

    private int currentEnemies = 1;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (currentEnemies < maxEnemies)
        {
            Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
            randomPosition.y = 0f; // Ensure enemies spawn at ground level
            Vector3 spawnPosition = transform.position + randomPosition;

            // Check if the spawn position is obstructed by other objects
            if (!Physics.CheckSphere(spawnPosition, 1f))
            {
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                currentEnemies++;
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
