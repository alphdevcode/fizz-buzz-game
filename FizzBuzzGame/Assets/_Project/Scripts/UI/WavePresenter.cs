using System;
using System.Collections;
using AlphDevCode.Managers;
using TMPro;
using UnityEngine;

namespace AlphDevCode.UI
{
    public class WavePresenter : MonoBehaviour
    {
        [SerializeField] private WavesManager wavesManager;
        [SerializeField] private TMP_Text waveText;

        private void OnEnable()
        {
            wavesManager.OnWaveStart += UpdateUI;
        }

        private void Start()
        {
            waveText.enabled = false;
        }

        private void UpdateUI(int waveNumber, bool isLastWave)
        {
            waveText.text = isLastWave ? "Infinite Wave" : $"Wave {waveNumber}";
            StartCoroutine(ShowTextForSeconds(1.5f));
        }

        private IEnumerator ShowTextForSeconds(float seconds)
        {
            waveText.enabled = true;
            yield return new WaitForSeconds(seconds);
            waveText.enabled = false;
        }

        private void OnDisable()
        {
            wavesManager.OnWaveStart -= UpdateUI;
        }
    }
}