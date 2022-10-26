﻿using System;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using AlphDevCode.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace AlphDevCode.UI
{
    public class WeaponSwitcherPresenter :MonoBehaviour
    {
        [SerializeField] private Weapon weapon;
        [SerializeField] private Image dumbWeaponImage;
        [SerializeField] private Image fizzWeaponImage;
        [SerializeField] private Image buzzWeaponImage;
        [SerializeField] private Image fizzBuzzWeaponImage;

        private const float SelectedAlpha = 1f;
        private const float DeselectedAlpha = .7f;

        private void OnEnable()
        {
            weapon.OnWeaponChange += UpdateUI;
        }

        private void Start()
        {
            UpdateUI(weapon.WeaponType);
        }

        private void UpdateUI(WeaponScriptableObject weaponType)
        {
            HighlightWeaponImage(dumbWeaponImage, 
                dumbWeaponImage.GetComponent<WeaponImageType>().WeaponType == weaponType);
            HighlightWeaponImage(fizzWeaponImage, 
                fizzWeaponImage.GetComponent<WeaponImageType>().WeaponType == weaponType);
            HighlightWeaponImage(buzzWeaponImage, 
                buzzWeaponImage.GetComponent<WeaponImageType>().WeaponType == weaponType);
            HighlightWeaponImage(fizzBuzzWeaponImage, 
                fizzBuzzWeaponImage.GetComponent<WeaponImageType>().WeaponType == weaponType);
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
            weapon.OnWeaponChange -= UpdateUI;
        }
    }
}