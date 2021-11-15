using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [Header("Enemy Setup")]
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float enemyMoveSpeed = 5f;

    [Header("Spawning Options")]
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0.5f;
    [SerializeField] float minTimeBetweenSpawns = 0.2f;

    [Header("Path Setup")]
    [SerializeField] Transform pathPrefab;

    

    public List<GameObject> GetEnemyObjects()
    {
        return enemyPrefabs;
    }

    public float GetMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    public float GetRandomSpawnInterval()
    {
        float spawnInterval = Random.Range(timeBetweenSpawns - spawnTimeVariance, timeBetweenSpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnInterval, minTimeBetweenSpawns, float.MaxValue);
    }

    public Transform GetFirstWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }
}
