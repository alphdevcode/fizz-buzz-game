using AlphDevCode.Enemies;
using AlphDevCode.Tools;
using UnityEngine;

namespace AlphDevCode.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New EnemyType", menuName = "EnemyType")]
    public class EnemyTypeScriptableObject : ScriptableObject
    {
        public string enemyName = FizzBuzzLogic.DumbName;
        public float movementSpeed = 1f;
        public Color enemyColor;
    }
}