using System;
using System.Collections;
using System.Collections.Generic;
using AlphDevCode.Enemies;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using UnityEngine;
using UnityEngine.Pool;

namespace AlphDevCode.Managers
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform enemiesContainer;
        [SerializeField] private Enemy enemyPrefab;
        
        private readonly SpawnBoundary _spawnBoundary = new();
        private readonly List<Enemy> _activeEnemies = new();
        private IObjectPool<Enemy> _enemyPool;
        
        private WaveScriptableObject _waveData;
        private int _enemiesLeft;
        private Coroutine _spawnCoroutine;

        public event Action OnWaveCompleted;

        public void InitializeWaveData(WaveScriptableObject wave)
        {
            _waveData = wave;
            _enemiesLeft = wave.enemiesAmount;
            _spawnCoroutine = StartCoroutine(StartSpawningEnemies());
        }

        private IEnumerator StartSpawningEnemies()
        {
            var enemiesToSpawn = _waveData.enemiesAmount;

            for (;;)
            {
                if (enemiesToSpawn == 0) break;

                yield return new WaitForSeconds(_waveData.spawnRate);
                SpawnEnemyAtRandomPosition();

                if (enemiesToSpawn != -1)
                    enemiesToSpawn--;
            }
        }

        public void StopSpawningEnemies()
        {
            StopCoroutine(_spawnCoroutine);
        }

        public void StopAllEnemiesMovement()
        {
            foreach (var enemy in _activeEnemies)
            {
                enemy.Movement.Stop();
            }
        }

        public void ReleaseAllEnemies()
        {
            foreach (var enemy in _activeEnemies)
            {
                _enemyPool.Release(enemy);
            }
            _activeEnemies.Clear();
        }

        private void Awake()
        {
            _enemyPool = new ObjectPool<Enemy>(
                CreateEnemy,
                OnGetEnemy,
                OnReleaseEnemy,
                OnDestroyEnemy,
                maxSize: 20);
        }

        #region PoolMethods

        private Enemy CreateEnemy()
        {
            Enemy enemy = Instantiate(enemyPrefab, enemiesContainer);
            enemy.SetPool(_enemyPool);
            return enemy;
        }

        private void OnGetEnemy(Enemy enemy)
        {
            enemy.gameObject.SetActive(true);
            _activeEnemies.Add(enemy);
        }

        private void OnReleaseEnemy(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            _activeEnemies.Remove(enemy);
            if(--_enemiesLeft == 0)
                OnWaveCompleted?.Invoke();
        }

        private void OnDestroyEnemy(Enemy enemy)
        {
            Destroy(enemy.gameObject);
        }

        #endregion

        private void SpawnEnemyAtRandomPosition()
        {
            var enemy = _enemyPool.Get();
            var point = _spawnBoundary.GetRandomSpawnPoint();
            var validIterations = 10;

            while (validIterations > 0 && !enemy.Movement.SetPosition(new Vector3(point.x, 0, point.y)))
            {
                point = _spawnBoundary.GetRandomSpawnPoint();
                validIterations--;
            }

            if (validIterations > 0)
                enemy.Initialize();
            else
            {
                _enemyPool.Release(enemy);
                Debug.LogError("Unable to find a valid position for the enemy to spawn.");
            }
        }
    }
}