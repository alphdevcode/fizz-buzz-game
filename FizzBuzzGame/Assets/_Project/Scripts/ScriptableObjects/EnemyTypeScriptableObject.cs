using AlphDevCode.Tools;
using UnityEngine;

namespace AlphDevCode.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New EnemyType", menuName = "EnemyType")]
    public class EnemyTypeScriptableObject : ScriptableObject
    {
        public FizzBuzzLogicType enemyType = FizzBuzzLogicType.Dumb;
        public float movementSpeed = 1f;
        public Color color;

        public int CalculateDamageToPlayer()
        {
            return enemyType switch
            {
                FizzBuzzLogicType.Dumb => 2,
                FizzBuzzLogicType.Fizz => 3,
                FizzBuzzLogicType.Buzz => 5,
                FizzBuzzLogicType.FizzBuzz => 15,
                _ => 0
            };
        }
    }
}