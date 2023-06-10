using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] protected Vector2 spawnZone;
    [SerializeField] protected int enemySpawnAmount;
    [SerializeField] protected int minEnemyBodyParts, maxEnemyBodyParts;
    [SerializeField] protected int foodSpawnAmount;

    [Header("References")]
    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] protected GameObject bodyPartPrefab;
    [SerializeField] protected List<GameObject> foodPrefabs;
    [SerializeField] protected Transform enemyPool, foodPool;


    void Start()
    {
        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
        for (int i = 0; i < foodSpawnAmount; i++)
        {
            SpawnFood();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Transform> CheckEventsOnPlace(Transform targetObject)
    {

        return null;
    }


    public void SpawnEnemy()
    {
        SpawnObject(true);

    }

    public void SpawnFood()
    {
        SpawnObject(false);
    }

    private Transform SpawnObject(bool objectIsEnemy)
    {
        //Set coordinates to spawn on
        Vector3 targetSpawnPosition = new Vector3(Random.Range(-spawnZone.x / 2, spawnZone.x / 2), 0, Random.Range(-spawnZone.y / 2, spawnZone.y / 2));
        Quaternion targetSpawnRotation = Quaternion.Euler(0, Random.Range(-1, 1) * 180, 0);
        //Instantiate object
        GameObject tempObject;
        if (objectIsEnemy)
        {
            tempObject = Instantiate(enemyPrefab, targetSpawnPosition, targetSpawnRotation, enemyPool);
            //Set enemy settings

        }
        else
        {
            int spawnObjectIndex = Random.Range(0, foodPrefabs.Count);
            tempObject = Instantiate(foodPrefabs[spawnObjectIndex], targetSpawnPosition, targetSpawnRotation, foodPool);

        }
        return tempObject.transform;
    }
}
