using AlphDevCode.Player;
using UnityEngine;

namespace AlphDevCode.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private WavesManager wavesManager;
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
            wavesManager.StopWaves();
            player.GetComponent<PlayerInput>().enabled = false;
        }

        private void StartGame()
        {
            enemySpawner.ReleaseAllEnemies();
            StartCoroutine(wavesManager.StartWave(0));
        }
        
        private void OnDisable()
        {
            player.OnPlayerDie += GameOver;
        }
    }
}
