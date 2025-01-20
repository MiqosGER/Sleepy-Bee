using UnityEngine;
using System.Collections.Generic;

public class WebSpawner : MonoBehaviour
{
    public List<GameObject> webPrefabs; // Liste von verschiedenen Prefabs
    public int poolSize = 10;          // Anzahl der Objekte im Pool
    public float spawnInterval = 1f;  // Zeitintervall für das Spawnen
    public float heightOffset = 2f;   // Höhenversatz für die Spawnposition
    public float spawnXPosition = 20f; // X-Position, wo Objekte erscheinen
    public float moveSpeed = 5f;      // Geschwindigkeit der Objekte

    private Transform playerTransform;  // Referenz zur Spielfigur
    private List<GameObject> objectPool; // Pool der Objekte
    private float nextSpawnTime = 0f;   // Zeit für den nächsten Spawn

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InitializePool();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnWebFromPool();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void InitializePool()
    {
        objectPool = new List<GameObject>();

        // Erstelle den Object Pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject web = Instantiate(GetRandomPrefab());
            web.SetActive(false); // Deaktivieren
            objectPool.Add(web);
        }
    }

    GameObject GetRandomPrefab()
    {
        // Zufälliges Prefab aus der Liste zurückgeben
        int randomIndex = Random.Range(0, webPrefabs.Count);
        return webPrefabs[randomIndex];
    }

    void SpawnWebFromPool()
    {
        foreach (GameObject web in objectPool)
        {
            if (!web.activeInHierarchy)
            {
                float yOffset = Random.Range(-heightOffset, heightOffset);
                Vector3 spawnPosition = new Vector3(playerTransform.position.x + spawnXPosition, yOffset, 0);
                web.transform.position = spawnPosition;
                web.SetActive(true);

                // Aktiviere alle deaktivierten Child-Objekte
                foreach (Transform child in web.transform)
                {
                    child.gameObject.SetActive(true);
                }

                // Füge dem Objekt das Bewegungs-Skript hinzu
                if (web.GetComponent<WebMover>() == null)
                {
                    web.AddComponent<WebMover>().Initialize(moveSpeed);
                }

                return;
            }
        }

        Debug.LogWarning("Pool exhausted! Consider increasing the pool size.");
    }
}