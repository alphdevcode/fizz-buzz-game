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

        private void OnEnable()
        {
            scoreManager.OnScoreChange += UpdateUI;
        }

        private void Start()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            scoreText.text = $"Score: {scoreManager.Score}";
        }

        private void OnDisable()
        {
            scoreManager.OnScoreChange -= UpdateUI;
        }
    }
}