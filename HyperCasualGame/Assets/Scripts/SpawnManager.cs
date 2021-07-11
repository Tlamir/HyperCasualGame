using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public float startDelay = 0.5f;
    public float spawnDelay = 1f;
    //Enemy random spawn Locations
    private float[] carSpawnLocations = new float[] { 12.58f, 9.584f, 6.588f, 3.592f, 0.596f, -2.4f };
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomCar", startDelay, spawnDelay);
    }
    void SpawnRandomCar()
    {
        Vector3 spawnPos = new Vector3(8.28f, 0, carSpawnLocations[ Random.Range(0, carSpawnLocations.Length)]);
        int carIndex = Random.Range(0, carPrefabs.Length);
        Instantiate(carPrefabs[carIndex], spawnPos, carPrefabs[carIndex].transform.rotation);
    }
}