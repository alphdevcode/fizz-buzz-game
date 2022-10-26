using AlphDevCode.ScriptableObjects;
using UnityEngine;

namespace AlphDevCode.UI
{
    public class WeaponImageType : MonoBehaviour
    {
        [SerializeField] private WeaponScriptableObject weaponType;

        public WeaponScriptableObject WeaponType => weaponType;
    }
}