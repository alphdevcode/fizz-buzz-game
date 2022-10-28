using System;
using System.Collections.Generic;
using AlphDevCode.UI;
using TMPro;
using UnityEngine;

namespace AlphDevCode.Managers
{
    public class UISwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject inGameUI;
        
        [SerializeField] private GameObject genericMenuUI;
        [SerializeField] private TMP_Text genericMenuUIMainText;
        [SerializeField] private TMP_Text genericMenuUICaption;

        private readonly List<GameObject> _uiScreenList = new();

        private GameObject _activeUI;

        public void ActivateInGameUI()
        {
            ChangeUI(UIScreen.InGame);
        }

        public void ActivateGenericMenuUI(GameStates state)
        {
            switch (state)
            {
                case GameStates.StartMenu:
                    genericMenuUIMainText.text = "Fizz Buzz Shadowland";
                    genericMenuUICaption.text = "Press any key to start";
                    break;
                case GameStates.GameOver:
                    genericMenuUIMainText.text = "Game Over";
                    genericMenuUICaption.text = "Press <color=#B7B7B7>[R]</color> to Retry";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, 
                        "State does not have a generic menu UI");
            }

            ChangeUI(UIScreen.GenericMenu);
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
            _uiScreenList.Add(genericMenuUI);
            _uiScreenList.Add(inGameUI);
        }
    }
}