using System;
using AlphDevCode.Player;
using UnityEngine;

namespace AlphDevCode.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private WavesManager wavesManager;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private PlayerHealth playerHealth;

        public event Action OnGameOver;
        public event Action OnStartGame;

        public void RetryGame()
        {
            StartGame();
            playerHealth.Revive();
            playerHealth.GetComponent<PlayerInput>().BlockInput(false);
        }

        private void OnEnable()
        {
            playerHealth.OnDie += GameOver;
        }

        private void Start()
        {
            StartGame();
        }

        private void GameOver()
        {
            OnGameOver?.Invoke();
            wavesManager.StopWaves();
            playerHealth.GetComponent<PlayerInput>().BlockInput(true);
            AudioSystem.instance.StopSound("BattleTheme");
            AudioSystem.instance.PlaySound("GameOverMusic");
        }

        private void StartGame()
        {
            OnStartGame?.Invoke();
            scoreManager.ResetScore();
            wavesManager.ReleaseAllEnemies();
            StartCoroutine(wavesManager.StartWave(0));
            AudioSystem.instance.StopSound("GameOverMusic");
            AudioSystem.instance.PlaySound("BattleTheme");
        }
        
        private void OnDisable()
        {
            playerHealth.OnDie += GameOver;
        }
    }
}
