using UnityEngine;

public class WebSpawner : MonoBehaviour
{
    public GameObject WebPrefab;  // Das Prefab für die Pipe
    public float spawnInterval = 2f;  // Zeitintervall, wie oft eine neue Pipe erscheint
    public float heightOffset = 2f;  // Höhenversatz für die Pipe
    public float spawnXPosition = 10f;  // X-Position, wo die Pipe erscheinen soll (rechts von der Spielfigur)
    
    private Transform playerTransform;  // Referenz zur Spielfigur

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;  // Annahme, dass der Spieler mit "Player" getaggt ist
        InvokeRepeating("SpawnPipe", 0f, spawnInterval);  // Wiederhole SpawnPipe alle 'spawnInterval' Sekunden
    }

    void SpawnWebs()
    {
        // Bestimme eine zufällige Y-Position innerhalb des gewünschten Bereichs
        float randomHeight = Random.Range(-heightOffset, heightOffset);
        
        // Erzeuge die Pipe rechts vom Spieler (an der X-Position 'spawnXPosition')
        Vector3 spawnPosition = new Vector3(playerTransform.position.x + spawnXPosition, randomHeight, 0);
        
        // Erzeuge die Pipe
        Instantiate(WebPrefab, spawnPosition, Quaternion.identity);
    }
}
