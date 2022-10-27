using System;
using System.Collections;
using AlphDevCode.ScriptableObjects;
using UnityEngine;

namespace AlphDevCode.Managers
{
    public class WavesManager : MonoBehaviour
    {
        [SerializeField] private WaveScriptableObject[] waves;
        [SerializeField] private EnemySpawner enemySpawner;

        private int _currentWaveIndex;
        private const float SecondsBetweenWaves = 2f;
        
        private bool IsLastWave => _currentWaveIndex == waves.Length - 1;
        
        public event Action<int, bool> OnWaveStart;

        public IEnumerator StartWave(int waveIndex)
        {
            if (waves[waveIndex].enemiesAmount == 0)
            {
                if (!IsLastWave)
                    StartCoroutine(StartWave(++_currentWaveIndex));
                yield break;
            }
            OnWaveStart?.Invoke(waveIndex + 1, waves[waveIndex].enemiesAmount == -1);
            yield return new WaitForSeconds(SecondsBetweenWaves);

            enemySpawner.InitializeWaveData(waves[waveIndex]);
        }

        public void StopWaves()
        {
            enemySpawner.StopSpawningEnemies();
            enemySpawner.StopAllEnemiesMovement();
        }

        private void CompleteWave()
        {
            if (!IsLastWave)
                StartCoroutine(StartWave(++_currentWaveIndex));
        }

        private void OnEnable()
        {
            enemySpawner.OnWaveCompleted += CompleteWave;
        }

        private void OnDisable()
        {
            enemySpawner.OnWaveCompleted -= CompleteWave;
        }

        public void ReleaseAllEnemies()
        {
            enemySpawner.ReleaseAllEnemies();
        }
    }
}