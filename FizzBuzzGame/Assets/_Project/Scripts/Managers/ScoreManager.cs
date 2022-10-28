using System;
using AlphDevCode.Enemies;
using AlphDevCode.Player;
using UnityEngine;

namespace AlphDevCode.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private const int BasePointsForMultiplierUpdate = 50;
        private const int MaxMultiplier = 5;
        private PlayerHealth _playerHealth;
        private int _pointsSinceMultiplierUpdate;
        
        public int Score { get; private set; }
        public int ScoreMultiplier { get; private set; } = 1;

        public event Action OnScoreChange;
        public event Action OnMultiplierChange;

        public void ResetScore()
        {
            Score = 0;
            OnScoreChange?.Invoke();
        }

        private void Awake()
        {
            Score = 0;
            _playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        }

        private void OnEnable()
        {
            EnemyHealth.OnDie += IncreaseScore;
            _playerHealth.OnDamageReceived += ResetMultiplier;
        }

        private void IncreaseScore(int value)
        {
            Score += value * ScoreMultiplier;
            _pointsSinceMultiplierUpdate += value;
            OnScoreChange?.Invoke();

            if (ScoreMultiplier < MaxMultiplier 
                && _pointsSinceMultiplierUpdate >= BasePointsForMultiplierUpdate * ScoreMultiplier)
                IncreaseMultiplier();
        }

        private void IncreaseMultiplier()
        {
            ScoreMultiplier++;
            _pointsSinceMultiplierUpdate = 0;
            OnMultiplierChange?.Invoke();
            AudioSystem.instance.PlaySound("ScoreMultiplierUp");
        }

        private void ResetMultiplier()
        {
            ScoreMultiplier = 1;
            _pointsSinceMultiplierUpdate = 0;
            OnMultiplierChange?.Invoke();
        }
    }
}