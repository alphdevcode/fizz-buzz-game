using System;
using AlphDevCode.Enemies;
using AlphDevCode.Player;
using UnityEngine;

namespace AlphDevCode.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private PlayerHealth _playerHealth;
        private int _scoreMultiplier;

        public int Score { get; private set; }
        
        public event Action OnScoreChange;

        private void Awake()
        {
            Score = 0;
            _playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        }

        private void OnEnable()
        {
            EnemyHealth.OnEnemyDie += IncreaseScore;
            _playerHealth.OnDamageReceived += DecreaseScore;
        }

        private void IncreaseScore(int value)
        {
            Score += value;
            OnScoreChange?.Invoke();
        }

        private void DecreaseScore(int value)
        {
            Score -= value;
            if (Score < 0) Score = 0;
            OnScoreChange?.Invoke();
        }
    }
}