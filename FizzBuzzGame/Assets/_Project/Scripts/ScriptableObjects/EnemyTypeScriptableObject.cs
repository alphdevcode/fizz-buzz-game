using AlphDevCode.Tools;
using UnityEngine;

namespace AlphDevCode.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New EnemyType", menuName = "EnemyType")]
    public class EnemyTypeScriptableObject : ScriptableObject
    {
        public FizzBuzzLogicType enemyType = FizzBuzzLogicType.Dumb;
        public Color color;
        public float movementSpeed = 1f;
        public float scaleMultiplier = 1f;

        public int GetFizzBuzzLogicValue()
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