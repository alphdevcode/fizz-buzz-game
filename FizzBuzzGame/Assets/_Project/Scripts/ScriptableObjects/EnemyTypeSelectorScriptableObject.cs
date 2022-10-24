using System.Collections.Generic;
using System.Linq;
using AlphDevCode.ScriptableObjects;
using UnityEngine;

namespace AlphDevCode.Enemies
{
    [CreateAssetMenu(fileName = "New EnemyTypeSelector", menuName = "EnemyTypeSelector")]
    public class EnemyTypeSelectorScriptableObject : ScriptableObject
    {
        [SerializeField] private List<EnemyTypeScriptableObject> enemyTypes;

        public EnemyTypeScriptableObject GetEnemyByTypeName(string enemyTypeName)
        {
            return enemyTypes.First(enemyType => enemyType.enemyName == enemyTypeName);
        }
    }
}