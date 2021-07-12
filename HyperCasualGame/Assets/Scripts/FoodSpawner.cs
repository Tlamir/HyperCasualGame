using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject player;

    public GameObject[] foodPrefabs;

    float foodSpawnLocationsTopRight = 5.0f;
    float foodSpawnLocationsTopLeft = -5.4f;
    float foodSpawnLocationsBottomRight = 3.0f;
    float foodSpawnLocationsBottomLeft = -3.0f;

    private float startDelay = 2;
    private float spawnDelay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomFoodTop();
    }
    public void SpawnRandomFoodTop()
    {
        Vector3 spawnPos = new Vector3(Random.Range(foodSpawnLocationsTopLeft,foodSpawnLocationsTopRight), 0.83f, 14.15f);
        int foodIndex = Random.Range(0, foodPrefabs.Length);
        Instantiate(foodPrefabs[foodIndex], spawnPos, foodPrefabs[foodIndex].transform.rotation);
    }
    public void SpawnRandomFoodBottom()
    {
        Vector3 spawnPos = new Vector3(Random.Range(foodSpawnLocationsBottomLeft, foodSpawnLocationsBottomRight), 0.83f, -5f);
        int foodIndex = Random.Range(0, foodPrefabs.Length);
        Instantiate(foodPrefabs[foodIndex], spawnPos, foodPrefabs[foodIndex].transform.rotation);
    }
    public void SpawnRandomFood()
    {
        if (player.transform.position.z > 12)
        {
            //Spawn in bottom
            SpawnRandomFoodBottom();
        }
        else
        {
            //Spawn in top
            SpawnRandomFoodTop();
        }
    }
}
