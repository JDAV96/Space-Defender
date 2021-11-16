using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> wavesInLevel;
    [SerializeField] float timeBetweenWaves = 1f;

    void Start()
    {
        StartCoroutine(SpawnWavesInLevel());
    }

    private IEnumerator SpawnWavesInLevel()
    {
        while (true)
        {
            foreach(WaveConfigSO wave in wavesInLevel)
            {
                yield return StartCoroutine(SpawnEnemies(wave));
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
    }

    private IEnumerator SpawnEnemies(WaveConfigSO wave)
    {
        List<GameObject> enemiesToSpawn = wave.GetEnemyObjects();
        foreach(GameObject enemy in enemiesToSpawn)
        {
            GameObject newEnemy = Instantiate(enemy, wave.GetFirstWaypoint().position, Quaternion.identity, transform);
            newEnemy.GetComponent<EnemyPathfinder>().SetWaveConfig(wave);
            yield return new WaitForSeconds(wave.GetRandomSpawnInterval());
        }
    }
}
