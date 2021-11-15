using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;

    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        List<GameObject> enemiesToSpawn = waveConfig.GetEnemyObjects();
        foreach(GameObject enemy in enemiesToSpawn)
        {
            GameObject newEnemy = Instantiate(enemy, waveConfig.GetFirstWaypoint().position, Quaternion.identity, transform);
            newEnemy.GetComponent<EnemyPathfinder>().SetWaveConfig(waveConfig);
        }
    }
}
