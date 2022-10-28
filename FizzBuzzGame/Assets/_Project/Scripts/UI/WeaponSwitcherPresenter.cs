using System;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using AlphDevCode.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace AlphDevCode.UI
{
    public class WeaponSwitcherPresenter :MonoBehaviour
    {
        [SerializeField] private RangeAttack rangeAttack;
        [SerializeField] private Image dumbWeaponImage;
        [SerializeField] private Image fizzWeaponImage;
        [SerializeField] private Image buzzWeaponImage;
        [SerializeField] private Image fizzBuzzWeaponImage;

        private const float SelectedAlpha = 1f;
        private const float DeselectedAlpha = .3f;

        private void OnEnable()
        {
            rangeAttack.OnWeaponChange += UpdateUI;
        }

        private void Start()
        {
            UpdateUI(rangeAttack.WeaponType);
        }

        private void UpdateUI(WeaponScriptableObject weaponType)
        {
            HighlightWeaponImage(dumbWeaponImage, 
                dumbWeaponImage.GetComponent<UIWeaponImageType>().WeaponType == weaponType);
            HighlightWeaponImage(fizzWeaponImage, 
                fizzWeaponImage.GetComponent<UIWeaponImageType>().WeaponType == weaponType);
            HighlightWeaponImage(buzzWeaponImage, 
                buzzWeaponImage.GetComponent<UIWeaponImageType>().WeaponType == weaponType);
            HighlightWeaponImage(fizzBuzzWeaponImage, 
                fizzBuzzWeaponImage.GetComponent<UIWeaponImageType>().WeaponType == weaponType);
        }

        private void HighlightWeaponImage(Image image, bool highlight = true)
        {
            ChangeAlpha(image, highlight ? SelectedAlpha : DeselectedAlpha);
        }
        

        private void ChangeAlpha(Image image, float alpha)
        {
            var tempColor = image.color;
            tempColor.a = alpha;
            image.color = tempColor;
        }

        private void OnDisable()
        {
            rangeAttack.OnWeaponChange -= UpdateUI;
        }
    }
}