using AlphDevCode.Player;
using UnityEngine;
using UnityEngine.UI;

namespace AlphDevCode.UI
{
    public class PlayerHealthPresenter : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private Slider playerHealthSlider;
        [SerializeField] private Image filler;
        [SerializeField] private Gradient gradient;

        private void OnEnable()
        {
            playerHealth.OnDamageReceived += UpdateUI;
        }

        private void Start()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            playerHealthSlider.value = playerHealth.CurrentHealth;
            filler.color = gradient.Evaluate(playerHealthSlider.normalizedValue);
        }

        private void OnDisable()
        {
            playerHealth.OnDamageReceived -= UpdateUI;
        }
    }
}