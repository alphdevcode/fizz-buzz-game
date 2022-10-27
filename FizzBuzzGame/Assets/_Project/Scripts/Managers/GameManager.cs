using System;
using AlphDevCode.Player;
using UnityEngine;

namespace AlphDevCode.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private WavesManager wavesManager;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private PlayerHealth player;

        public event Action OnGameOver;
        public event Action OnStartGame;

        public void RetryGame()
        {
            StartGame();        
            player.GetComponent<PlayerInput>().enabled = true;
        }

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
            OnGameOver?.Invoke();
            wavesManager.StopWaves();
            player.GetComponent<PlayerInput>().enabled = false;
        }

        private void StartGame()
        {
            OnStartGame?.Invoke();
            scoreManager.ResetScore();
            wavesManager.ReleaseAllEnemies();
            StartCoroutine(wavesManager.StartWave(0));
        }
        
        private void OnDisable()
        {
            player.OnPlayerDie += GameOver;
        }
    }
}
