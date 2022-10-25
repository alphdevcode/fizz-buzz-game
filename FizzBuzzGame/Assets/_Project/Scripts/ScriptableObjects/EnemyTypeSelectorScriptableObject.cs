using System.Collections.Generic;
using System.Linq;
using AlphDevCode.Tools;
using UnityEngine;

namespace AlphDevCode.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New EnemyTypeSelector", menuName = "EnemyTypeSelector")]
    public class EnemyTypeSelectorScriptableObject : ScriptableObject
    {
        [SerializeField] private List<EnemyTypeScriptableObject> enemyTypes;

        public EnemyTypeScriptableObject GetEnemyData(FizzBuzzLogicType enemyType)
        {
            return enemyTypes.First(enemy => enemy.enemyType == enemyType);
        }
    }
}