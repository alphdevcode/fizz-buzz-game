using System.Collections;
using AlphDevCode.Player;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerHealthTests
    {
        private const string EnemyTypeSelectorPath = "Assets/_Project/Scripts/Enemies/Data/EnemyTypeSelector.asset";

        private readonly EnemyTypeSelectorScriptableObject _enemyTypeSelector =
            AssetDatabase.LoadAssetAtPath<EnemyTypeSelectorScriptableObject>(EnemyTypeSelectorPath);

        [UnityTest]
        public IEnumerator Given_TakeDamage_Then_ReduceHealth()
        {
            var gameObject = new GameObject();
            var playerHealth = gameObject.AddComponent<PlayerHealth>();
            var enemyDataTest = _enemyTypeSelector.GetEnemyData(FizzBuzzLogicType.Dumb);
            
            yield return null;
            
            var initialHealth = playerHealth.CurrentHealth;
            
            playerHealth.TakeDamage(enemyDataTest);
            
            Assert.Less(playerHealth.CurrentHealth, initialHealth);
        }
    }
}