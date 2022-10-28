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
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private UISwitcher uiSwitcher;
        
        public GameStates CurrentState { get; private set; }
        
        public void RetryGame()
        {
            StartGame();
            playerHealth.Revive();
        }

        private void OnEnable()
        {
            playerHealth.OnDie += GameOver;
        }

        private void Start()
        {
            uiSwitcher.ActivateGenericMenuUI(CurrentState = GameStates.StartMenu);
            playerInput.BlockInput(true);
            AudioSystem.instance.PlaySound("BattleTheme");
        }

        private void GameOver()
        {
            uiSwitcher.ActivateGenericMenuUI(CurrentState = GameStates.GameOver);
            playerInput.BlockInput(true);
            wavesManager.StopWaves();
            AudioSystem.instance.StopSound("BattleTheme");
            AudioSystem.instance.PlaySound("GameOverMusic");
        }

        public void StartGame()
        {
            playerInput.BlockInput(false);

            uiSwitcher.ActivateInGameUI();
            scoreManager.ResetScore();
            wavesManager.ReleaseAllEnemies();
            StartCoroutine(wavesManager.StartWave(0));
            AudioSystem.instance.StopSound("GameOverMusic");
            AudioSystem.instance.PlaySound("BattleTheme");
            CurrentState = GameStates.Battle;
        }
        
        private void OnDisable()
        {
            playerHealth.OnDie += GameOver;
        }
    }
}
