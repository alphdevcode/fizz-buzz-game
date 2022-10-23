using AlphDevCode.Enemies;
using UnityEngine;

namespace AlphDevCode.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy")]
    public class EnemyScriptableObject : ScriptableObject
    {
        public EnemyType enemyType = EnemyType.DUMB;
        public float movementSpeed = 1f;
    }
}