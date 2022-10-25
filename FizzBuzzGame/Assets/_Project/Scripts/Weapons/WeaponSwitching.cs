using System;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using UnityEngine;

namespace AlphDevCode.Weapons
{
    [RequireComponent(typeof(Weapon))]
    public class WeaponSwitching : MonoBehaviour
    {
        [SerializeField] private WeaponSelectorScriptableObject weaponSelector;
        private Weapon _weapon;

        private void Start()
        {
            _weapon = GetComponent<Weapon>();
        }

        public void NextWeapon()
        {
            _weapon.SetData(weaponSelector.GetNextWeaponData());
        }
        
        public void PreviousWeapon()
        {
            _weapon.SetData(weaponSelector.GetPreviousWeaponData());
        }


        public void ChangeWeapon(FizzBuzzLogicType weaponType)
        {
            _weapon.SetData(weaponSelector.GetWeaponData(weaponType, true));
        }
    }
}
