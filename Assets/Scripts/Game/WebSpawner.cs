using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WebSpawner : MonoBehaviour
{
    public List<GameObject> webPrefabs; // List of different prefabs
    public int poolSize = 10;          // Number of objects in the pool
    public float spawnInterval = 1f;  // Interval between spawns
    public float heightOffset = 2f;   // Vertical offset for spawn position
    public float spawnXPosition = 20f; // X position where objects spawn
    public float moveSpeed = 5f;      // Speed of the objects

    private Transform playerTransform;  // Reference to the player character
    private Queue<GameObject> objectPool; // Object pool for reusable objects

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InitializePool();
        StartCoroutine(SpawnWebs());
    }

    void InitializePool()
    {
        objectPool = new Queue<GameObject>();

        // Create the object pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject web = Instantiate(GetRandomPrefab());
            web.SetActive(false); // Disable initially
            objectPool.Enqueue(web);
        }
    }

    GameObject GetRandomPrefab()
    {
        // Return a random prefab from the list
        int randomIndex = Random.Range(0, webPrefabs.Count);
        return webPrefabs[randomIndex];
    }

    IEnumerator SpawnWebs()
    {
        while (true) // Infinite loop for continuous spawning
        {
            SpawnWebFromPool();
            yield return new WaitForSeconds(spawnInterval); // Wait for the specified interval
        }
    }

    void SpawnWebFromPool()
    {
        if (objectPool.Count > 0)
        {
            GameObject web = objectPool.Dequeue();
            float yOffset = Random.Range(-heightOffset, heightOffset);
            Vector3 spawnPosition = new Vector3(playerTransform.position.x + spawnXPosition, yOffset, 0);
            web.transform.position = spawnPosition;
            web.SetActive(true);

            // Reactivate all child objects
            foreach (Transform child in web.transform)
            {
                child.gameObject.SetActive(true);
            }

            // Add movement script if not already present
            if (web.GetComponent<WebMover>() == null)
            {
                web.AddComponent<WebMover>().Initialize(moveSpeed);
            }

            // Return the object to the pool when it is deactivated
            StartCoroutine(ReturnToPoolWhenInactive(web));
        }
        else
        {
            Debug.LogWarning("Pool exhausted! Consider increasing the pool size.");
        }
    }

    IEnumerator ReturnToPoolWhenInactive(GameObject web)
    {
        // Wait until the object becomes inactive
        while (web.activeInHierarchy)
        {
            yield return null;
        }

        web.SetActive(false);
        objectPool.Enqueue(web);
    }
}
