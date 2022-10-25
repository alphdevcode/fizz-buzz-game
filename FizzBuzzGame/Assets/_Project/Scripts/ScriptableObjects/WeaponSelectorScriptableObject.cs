using System.Collections.Generic;
using System.Linq;
using AlphDevCode.Tools;
using AlphDevCode.Utilities;
using UnityEngine;

namespace AlphDevCode.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New WeaponSelector", menuName = "WeaponSelector")]
    public class WeaponSelectorScriptableObject : ScriptableObject
    {
        [SerializeField] private List<WeaponScriptableObject> weaponTypes;

        private int _weaponSelectedIndex = 0;

        public WeaponScriptableObject GetWeaponData(FizzBuzzLogicType fizzBuzzLogicType, bool updateIndex = false)
        {
            var weaponData = weaponTypes.First(weaponType => weaponType.targetEnemyType.enemyType == fizzBuzzLogicType);
            if (updateIndex) SetWeaponSelectedIndex(weaponData);
            return weaponData;
        }

        public WeaponScriptableObject GetNextWeaponData()
        {
            var weaponData = weaponTypes.GetItemAfter(weaponTypes[_weaponSelectedIndex]);
            SetWeaponSelectedIndex(weaponData);
            return weaponData;
        }

        public WeaponScriptableObject GetPreviousWeaponData()
        {
            var weaponData = weaponTypes.GetItemBefore(weaponTypes[_weaponSelectedIndex]);
            SetWeaponSelectedIndex(weaponData);
            return weaponData;
        }

        private void SetWeaponSelectedIndex(WeaponScriptableObject weaponData)
        {
            _weaponSelectedIndex = weaponTypes.IndexOf(weaponData);
        }
    }
}