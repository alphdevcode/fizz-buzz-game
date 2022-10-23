using AlphDevCode.Enemies;
using UnityEngine;

namespace AlphDevCode.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon")]
    public class WeaponScriptableObject : ScriptableObject
    {
        public EnemyTypeScriptableObject targetEnemyType;
        public float shootingInterval = .5f;
        public GameObject weaponMesh;
        public GameObject projectileMesh;
    }
}