using AlphDevCode.Enemies;
using UnityEngine;

namespace AlphDevCode.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New EnemyType", menuName = "EnemyType")]
    public class EnemyTypeScriptableObject : ScriptableObject
    {
        public string enemyName = "Dumb";
        public float movementSpeed = 1f;
    }
}