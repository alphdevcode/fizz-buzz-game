using System.Collections;
using AlphDevCode.Enemies;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using NUnit.Framework;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EnemyTests
    {
        private const string EnemyTypeSelectorPath = "Assets/_Project/Scripts/Enemies/Data/EnemyTypeSelector.asset";
        private const string FizzBuzzNumberTextPath = "Assets/_Project/Prefabs/Units/FizzBuzzNumber.prefab";

        private readonly EnemyTypeSelectorScriptableObject _enemyTypeSelector =
            AssetDatabase.LoadAssetAtPath<EnemyTypeSelectorScriptableObject>(EnemyTypeSelectorPath);

        private readonly TMP_Text _fizzBuzzNumberText = AssetDatabase.LoadAssetAtPath<TMP_Text>(FizzBuzzNumberTextPath);

        private static FizzBuzzLogicType[] _fizzBuzzLogicTypes =
        {
            FizzBuzzLogicType.Dumb,
            FizzBuzzLogicType.Fizz,
            FizzBuzzLogicType.Buzz,
            FizzBuzzLogicType.FizzBuzz
        };
        
        private EnemyHealth _enemyHealth;

        [OneTimeSetUp]
        public void SetUpEnemy()
        {
            var enemy = new GameObject().AddComponent<Enemy>();
            _enemyHealth = enemy.gameObject.AddComponent<EnemyHealth>();
            _enemyHealth.Enemy = enemy;
            enemy.FizzBuzzNumberText = _fizzBuzzNumberText;
        }

        [UnityTest]
        public IEnumerator Given_TakeDamageSameType_Then_Die(
            [ValueSource(nameof(_fizzBuzzLogicTypes))]
            FizzBuzzLogicType fizzBuzzLogicType)
        {
            var enemyData = _enemyTypeSelector.GetEnemyData(fizzBuzzLogicType);

            var enemyHealth = _enemyHealth;
            
            enemyHealth.GetComponent<Enemy>().EnemyType = enemyData;
            enemyHealth.TakeDamage(enemyData);

            yield return null;
            Assert.IsTrue(enemyHealth.IsDead);
        }

        [UnityTest]
        public IEnumerator Given_TakeDamageDifferentType_Then_DoNotDie(
            [NUnit.Framework.Range(0, 3)] int fizzBuzzTypeIndex)
        {
            var enemyData = _enemyTypeSelector.GetEnemyData(_fizzBuzzLogicTypes[fizzBuzzTypeIndex]);
            var enemyHealth = _enemyHealth;
            enemyHealth.GetComponent<Enemy>().EnemyType = enemyData;
            
            yield return null;

            for (var i = 0; i < _fizzBuzzLogicTypes.Length; i++)
            {
                if (i == fizzBuzzTypeIndex) continue;

                var bulletEnemyData = _enemyTypeSelector.GetEnemyData(_fizzBuzzLogicTypes[i]);
                enemyHealth.TakeDamage(bulletEnemyData);

                Assert.IsFalse(enemyHealth.IsDead);
            }
        }
    }
}