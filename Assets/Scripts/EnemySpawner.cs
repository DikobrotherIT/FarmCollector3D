using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyList;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    private float _elapsedTime = 0;
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            _elapsedTime = 0;
            int randomSpawnPoint = Random.Range(0, _spawnPoints.Count);
            int randomEnemyPrefab = Random.Range(0, _enemyList.Count);
            SpawnEnemy(_enemyList[randomEnemyPrefab], _spawnPoints[randomSpawnPoint]);
        }
    }

    private void SpawnEnemy(GameObject enemy, Transform spawnPosition)
    {
        Instantiate(enemy, spawnPosition.position, Quaternion.identity);
    }
}
