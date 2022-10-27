using System;
using System.Collections;
using System.Collections.Generic;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.UI;
using UnityEngine;

namespace AlphDevCode.Managers
{
    public class UISwitcher : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        [SerializeField] private GameObject inGameUI;
        [SerializeField] private GameObject gameOverUI;

        private readonly List<GameObject> _uiScreenList = new();

        private GameObject _activeUI;

        private void ActivateInGameUI()
        {
            ChangeUI(UIScreen.InGame);
        }

        private void ActivateGameOverUI()
        {
            ChangeUI(UIScreen.GameOver);
        }

        private void ChangeUI(UIScreen uiToActivate)
        {
            for (var i = 0; i < _uiScreenList.Count; i++)
            {
                _uiScreenList[i].SetActive(i == (int)uiToActivate);
            }
        }

        private void Start()
        {
            PopulateUIList();
        }

        private void PopulateUIList()
        {
            _uiScreenList.Insert((int)UIScreen.InGame, inGameUI);
            _uiScreenList.Insert((int)UIScreen.GameOver, gameOverUI);
        }

        private void OnEnable()
        {
            gameManager.OnStartGame += ActivateInGameUI;
            gameManager.OnGameOver += ActivateGameOverUI;
        }

        private void OnDisable()
        {
            gameManager.OnStartGame -= ActivateInGameUI;
            gameManager.OnGameOver -= ActivateGameOverUI;
        }
    }
}