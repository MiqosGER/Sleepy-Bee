using UnityEngine;
using System.Collections.Generic;

public class WebSpawner : MonoBehaviour
{
    public List<GameObject> webPrefabs; // Liste von verschiedenen Prefabs
    public int poolSize = 10;          // Anzahl der Objekte im Pool
    public float spawnInterval = 2f;  // Zeitintervall für das Spawnen
    public float heightOffset = 2f;   // Höhenversatz für die Spawnposition
    public float spawnXPosition = 10f; // X-Position, wo Objekte erscheinen
    public float moveSpeed = 5f;      // Geschwindigkeit der Objekte

    private Transform playerTransform;  // Referenz zur Spielfigur
    private List<GameObject> upperPool; // Pool für obere Objekte
    private List<GameObject> lowerPool; // Pool für untere Objekte

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InitializePools();
        InvokeRepeating("SpawnWebs", 0f, spawnInterval); // Wiederholtes Spawnen starten
    }

    void InitializePools()
    {
        upperPool = new List<GameObject>();
        lowerPool = new List<GameObject>();

        // Erstelle den Object Pool
        for (int i = 0; i < poolSize; i++)
        {
            // Zufälliges Prefab aus der Liste auswählen
            GameObject upperWeb = Instantiate(GetRandomPrefab());
            upperWeb.SetActive(false); // Deaktivieren
            upperPool.Add(upperWeb);

            GameObject lowerWeb = Instantiate(GetRandomPrefab());
            lowerWeb.SetActive(false); // Deaktivieren
            lowerPool.Add(lowerWeb);
        }
    }

    GameObject GetRandomPrefab()
    {
        // Zufälliges Prefab aus der Liste zurückgeben
        int randomIndex = Random.Range(0, webPrefabs.Count);
        return webPrefabs[randomIndex];
    }

    void SpawnWebs()
    {
        // Obere und untere Objekte spawnen
        SpawnWebFromPool(upperPool, Random.Range(0f, heightOffset));
        SpawnWebFromPool(lowerPool, Random.Range(-heightOffset, 0f));
    }

    void SpawnWebFromPool(List<GameObject> pool, float yOffset)
    {
        foreach (GameObject web in pool)
        {
            if (!web.activeInHierarchy)
            {
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
