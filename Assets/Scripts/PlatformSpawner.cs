using UnityEngine;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public float levelWidth = 3f;     // maximale horizontale Ausbreitung
    public float minY = 1.5f;         // minimaler Abstand zwischen Plattformen
    public float maxY = 2.5f;         // maximaler Abstand
    public int initialPlatformCount = 20;

    private float lastSpawnY = 0f;

    void Start()
    {
        // Initiale Plattformen erzeugen
        for (int i = 0; i < initialPlatformCount; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // Neue Plattformen erzeugen, wenn der Spieler hochsteigt
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player && player.transform.position.y + 10f > lastSpawnY)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        float y = lastSpawnY + Random.Range(minY, maxY);
        float x = Random.Range(-levelWidth, levelWidth);
        Vector3 spawnPosition = new Vector3(x, y, 0);
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        lastSpawnY = y;
    }
    public void ResetPlatforms()
    {
        // Alle Plattformen zerstören
        foreach (GameObject platform in GameObject.FindGameObjectsWithTag("Ground"))
        {
            Destroy(platform);
        }
        lastSpawnY = 0f; // Reset der letzten Y-Position
        Start(); // Erzeuge die initialen Plattformen neu
    }
}