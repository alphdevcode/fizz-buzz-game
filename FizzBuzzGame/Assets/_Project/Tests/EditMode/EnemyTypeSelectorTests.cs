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
        [TestCase(FizzBuzzLogicType.DUMB, "DumbEnemy")]
        [TestCase(FizzBuzzLogicType.FIZZ, "FizzEnemy")]
        [TestCase(FizzBuzzLogicType.BUZZ, "BuzzEnemy")]
        [TestCase(FizzBuzzLogicType.FIZZBUZZ, "FizzBuzzEnemy")]
        public void Given_FizzBuzzLogicName_Then_EnemyType(FizzBuzzLogicType fizzBuzzLogicType,
            string expectedEnemyTypeName)
        {
            var enemyType =
                AssetDatabase.LoadAssetAtPath<EnemyTypeScriptableObject>($"{EnemyDataPath}/{expectedEnemyTypeName}.asset");

            Assert.AreEqual(enemyType, _enemyTypeSelector.GetEnemyData(fizzBuzzLogicType));
        }
    }
}