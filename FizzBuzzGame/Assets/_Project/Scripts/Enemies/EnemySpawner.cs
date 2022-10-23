using System;
using System.Collections;
using AlphDevCode.Tools;
using UnityEngine;


namespace AlphDevCode.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        private SpawnBoundary _spawnBoundary;

        private void Start()
        {
            _spawnBoundary = new SpawnBoundary();
            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            var enemiesLeft = 20;
            while (enemiesLeft > 0)
            {
                SpawnEnemyAtRandomPosition();
                enemiesLeft--;
                yield return new WaitForSeconds(1f);
            }
        }

        private void SpawnEnemyAtRandomPosition()
        {
            var point = _spawnBoundary.GetRandomSpawnPoint();
            Instantiate(enemyPrefab, new Vector3(point.x, 0, point.y), Quaternion.identity);
        }
    }
}