using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyType> enemyTypes; 

    public Transform spawnPoint;   
    public float spawnInterval = 5f; 

    private float nextSpawnTime = 0f;

    [System.Serializable]
    public class EnemyType
    {
        public string typeName;       
        public GameObject enemyPrefab; 
        public float spawnProbability; 
    }

    private void Start()
    {
        
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        
        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnRandomEnemy()
    {
        
        EnemyType randomType = GetRandomEnemyType();

        if (randomType != null)
        {
            
            GameObject newEnemy = Instantiate(randomType.enemyPrefab, spawnPoint.position, Quaternion.identity);

            
        }
    }

    private EnemyType GetRandomEnemyType()
    {
        float randomValue = Random.value;
        float totalProbability = 0f;

        foreach (EnemyType type in enemyTypes)
        {
            totalProbability += type.spawnProbability;

            if (randomValue < totalProbability)
            {
                return type;
            }
        }

        return null;
    }
}
