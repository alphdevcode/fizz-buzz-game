using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using NUnit.Framework;
using UnityEditor;

namespace Tests
{
    public class EnemyTypeSelectorTests
    {
        private EnemyTypeSelectorScriptableObject _enemyTypeSelector;

        [OneTimeSetUp]
        public void InitializeEnemyTypeSelector()
        {
            var assetNames = AssetDatabase.FindAssets("EnemyTypeSelector", 
                    new[] { "Assets/_Project/Scripts/Enemies/Data" });
            var assetPath = AssetDatabase.GUIDToAssetPath(assetNames[0]);
            _enemyTypeSelector = AssetDatabase.LoadAssetAtPath<EnemyTypeSelectorScriptableObject>(assetPath);
        }

        [Test]
        [TestCase(FizzBuzzLogicType.DUMB, "DumbEnemy")]
        [TestCase(FizzBuzzLogicType.FIZZ, "FizzEnemy")]
        [TestCase(FizzBuzzLogicType.BUZZ, "BuzzEnemy")]
        [TestCase(FizzBuzzLogicType.FIZZBUZZ, "FizzBuzzEnemy")]
        public void Given_FizzBuzzLogicName_Then_EnemyType(FizzBuzzLogicType fizzBuzzLogicType,
            string expectedEnemyTypeName)
        {
            var assetNames = AssetDatabase.FindAssets($"{expectedEnemyTypeName}",
                new[] { "Assets/_Project/Scripts/Enemies/Data" });
            var assetPath = AssetDatabase.GUIDToAssetPath(assetNames[0]);
            var enemyType = AssetDatabase.LoadAssetAtPath<EnemyTypeScriptableObject>(assetPath);

            Assert.AreEqual(enemyType, _enemyTypeSelector.GetEnemyData(fizzBuzzLogicType));
        }
    }
}