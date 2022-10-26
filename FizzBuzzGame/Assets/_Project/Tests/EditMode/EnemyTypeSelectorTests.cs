using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using NUnit.Framework;
using UnityEditor;

namespace Tests
{
    public class EnemyTypeSelectorTests
    {
        private const string EnemyDataPath = "Assets/_Project/Scripts/Enemies/Data";

        private readonly EnemyTypeSelectorScriptableObject _enemyTypeSelector =
            AssetDatabase.LoadAssetAtPath<EnemyTypeSelectorScriptableObject>(
                $"{EnemyDataPath}/EnemyTypeSelector.asset");


        [Test]
        [TestCase(FizzBuzzLogicType.Dumb, "DumbEnemy")]
        [TestCase(FizzBuzzLogicType.Fizz, "FizzEnemy")]
        [TestCase(FizzBuzzLogicType.Buzz, "BuzzEnemy")]
        [TestCase(FizzBuzzLogicType.FizzBuzz, "FizzBuzzEnemy")]
        public void Given_FizzBuzzLogicName_Then_EnemyType(FizzBuzzLogicType fizzBuzzLogicType,
            string expectedEnemyTypeName)
        {
            var enemyType =
                AssetDatabase.LoadAssetAtPath<EnemyTypeScriptableObject>(
                    $"{EnemyDataPath}/{expectedEnemyTypeName}.asset");

            Assert.AreEqual(enemyType, _enemyTypeSelector.GetEnemyData(fizzBuzzLogicType));
        }

        [Test]
        [TestCase(FizzBuzzLogicType.Dumb, 2)]
        [TestCase(FizzBuzzLogicType.Fizz, 3)]
        [TestCase(FizzBuzzLogicType.Buzz, 5)]
        [TestCase(FizzBuzzLogicType.FizzBuzz, 15)]
        public void Given_EnemyType_Then_DamageToPlayerAmount(FizzBuzzLogicType type, int expectedDamage)
        {
            var enemyType = _enemyTypeSelector.GetEnemyData(type);

            Assert.AreEqual(expectedDamage, enemyType.CalculateDamageToPlayer());
        }
    }
}