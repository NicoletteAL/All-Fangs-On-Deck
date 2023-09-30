using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnRate = 1f;

    public float minFallSpeed = 2f;
    public float maxFallSpeed = 6f;

    private float nextSpawnTime;



    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnPrefab();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnPrefab()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).x, Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x), Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).y, 0);
        GameObject newPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = newPrefab.GetComponent<Rigidbody2D>();
        float randomFallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
        rb.velocity = Vector2.down * randomFallSpeed;

        Destroy(newPrefab, 5f);
    }
    
}
