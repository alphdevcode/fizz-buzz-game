using System.Collections;
using AlphDevCode.Enemies;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EnemyTests
    {
        private const string EnemyPrefabPath = "Assets/_Project/Prefabs/Enemy.prefab";
        private const string EnemyTypeSelectorPath = "Assets/_Project/Scripts/Enemies/Data/EnemyTypeSelector.asset";

        private readonly Enemy _enemyPrefab = AssetDatabase.LoadAssetAtPath<Enemy>(EnemyPrefabPath);

        private readonly EnemyTypeSelectorScriptableObject _enemyTypeSelector =
            AssetDatabase.LoadAssetAtPath<EnemyTypeSelectorScriptableObject>(EnemyTypeSelectorPath);
        
        private static FizzBuzzLogicType[] _fizzBuzzLogicTypes =
        {
            FizzBuzzLogicType.Dumb,
            FizzBuzzLogicType.Fizz,
            FizzBuzzLogicType.Buzz,
            FizzBuzzLogicType.FizzBuzz
        };
        
        [UnityTest]
        public IEnumerator Given_TakeDamageSameType_Then_Die(
            [ValueSource(nameof(_fizzBuzzLogicTypes))]
            FizzBuzzLogicType fizzBuzzLogicType)
        {
            var enemyData = _enemyTypeSelector.GetEnemyData(fizzBuzzLogicType);

            var enemy = GameObject.Instantiate(_enemyPrefab);


            enemy.SetEnemyTypeData(enemyData);

            var enemyHealth = enemy.GetComponentInChildren<EnemyHealth>();
            enemyHealth.TakeDamage(enemyData);

            yield return null;
            Assert.IsFalse(enemyHealth.GetComponent<BoxCollider>().enabled);
        }

        [UnityTest]
        public IEnumerator Given_TakeDamageDifferentType_Then_DoNotDie(
            [NUnit.Framework.Range(0, 3)] int fizzBuzzTypeIndex)
        {
            var enemyData = _enemyTypeSelector.GetEnemyData(_fizzBuzzLogicTypes[fizzBuzzTypeIndex]);

            var enemy = GameObject.Instantiate(_enemyPrefab);
            yield return null;
            
            enemy.SetEnemyTypeData(enemyData);

            for (var i = 0; i < _fizzBuzzLogicTypes.Length; i++)
            {
                if (i == fizzBuzzTypeIndex) continue;
                
                var bulletEnemyData = _enemyTypeSelector.GetEnemyData(_fizzBuzzLogicTypes[i]);
                var enemyHealth = enemy.GetComponentInChildren<EnemyHealth>();
                enemyHealth.TakeDamage(bulletEnemyData);
                
                var isNotDead = enemyHealth.GetComponent<BoxCollider>().enabled;
                Assert.IsTrue(isNotDead);
            }
        }
    }
}