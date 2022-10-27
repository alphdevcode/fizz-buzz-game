using System;
using AlphDevCode.Enemies;
using AlphDevCode.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AlphDevCode.UI
{
    public class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text multiplierText;

        private void OnEnable()
        {
            scoreManager.OnScoreChange += UpdateScoreUI;
            scoreManager.OnMultiplierChange += UpdateMultiplierUI;
        }

        private void Start()
        {
            UpdateScoreUI();
            UpdateMultiplierUI();
        }

        private void UpdateMultiplierUI()
        {
            multiplierText.text = scoreManager.ScoreMultiplier == 1 
                ? string.Empty : $"x{scoreManager.ScoreMultiplier}";
        }

        private void UpdateScoreUI()
        {
            scoreText.text = $"Score: {scoreManager.Score}";
        }

        private void OnDisable()
        {
            scoreManager.OnScoreChange -= UpdateScoreUI;
        }
    }
}