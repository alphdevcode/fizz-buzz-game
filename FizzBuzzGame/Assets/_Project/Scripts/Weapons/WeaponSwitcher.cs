using System;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using UnityEngine;

namespace AlphDevCode.Weapons
{
    [RequireComponent(typeof(RangeAttack))]
    public class WeaponSwitcher : MonoBehaviour
    {
        [SerializeField] private WeaponSelectorScriptableObject weaponSelector;
        private RangeAttack _rangeAttack;
        
        private void Start()
        {
            _rangeAttack = GetComponent<RangeAttack>();
        }

        public void NextWeapon()
        {
            _rangeAttack.SetData(weaponSelector.GetNextWeaponData());
        }
        
        public void PreviousWeapon()
        {
            _rangeAttack.SetData(weaponSelector.GetPreviousWeaponData());
        }


        public void ChangeWeapon(FizzBuzzLogicType weaponType)
        {
            _rangeAttack.SetData(weaponSelector.GetWeaponData(weaponType, true));
        }

    }
}
