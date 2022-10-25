using AlphDevCode.Enemies;
using AlphDevCode.Tools;
using UnityEngine;

namespace AlphDevCode.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New EnemyType", menuName = "EnemyType")]
    public class EnemyTypeScriptableObject : ScriptableObject
    {
        public FizzBuzzLogicType enemyType = FizzBuzzLogicType.DUMB;
        public float movementSpeed = 1f;
        public Color color;
    }
}