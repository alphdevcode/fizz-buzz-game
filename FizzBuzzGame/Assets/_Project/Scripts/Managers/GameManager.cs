using System;
using AlphDevCode.Player;
using UnityEngine;

namespace AlphDevCode.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private PlayerHealth player;

        private void OnEnable()
        {
            player.OnPlayerDie += GameOver;
        }

        private void Start()
        {
            StartGame();
        }

        private void GameOver()
        {
            enemySpawner.StopSpawningEnemies();
            enemySpawner.StopEnemiesMovement();
            player.GetComponent<PlayerInput>().enabled = false;
        }

        private void StartGame()
        {
            enemySpawner.ReleaseAllEnemies();
            enemySpawner.StartSpawningEnemies();
        }
        
        private void OnDisable()
        {
            player.OnPlayerDie += GameOver;
        }
    }
}
