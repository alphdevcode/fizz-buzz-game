using AlphDevCode.Enemies;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using NUnit.Framework;
using UnityEditor;

namespace AlphDevCode.Test.EditMode
{
    public class EnemyTypeSelectorTests
    {
        [TestCase(FizzBuzzLogic.DumbName, "DumbEnemy")]
        [TestCase(FizzBuzzLogic.FizzName, "FizzEnemy")]
        [TestCase(FizzBuzzLogic.BuzzName, "BuzzEnemy")]
        [TestCase(FizzBuzzLogic.FizzBuzzName, "FizzBuzzEnemy")]
        [Test]
        public void Given_FizzBuzzLogicName_Then_EnemyType(string fizzBuzzLogicName, string expectedEnemyType)
        {
            var assetNames = AssetDatabase.FindAssets("EnemyTypeSelector",new[] {"Assets/_Project/Scripts/Enemies/Data"});
            var assetPath = AssetDatabase.GUIDToAssetPath(assetNames[0]);
            var enemyTypeSelector = AssetDatabase.LoadAssetAtPath<EnemyTypeSelectorScriptableObject>(assetPath);
            
            assetNames = AssetDatabase.FindAssets($"{expectedEnemyType}",new[] {"Assets/_Project/Scripts/Enemies/Data"});
            assetPath = AssetDatabase.GUIDToAssetPath(assetNames[0]);
            var enemyType = AssetDatabase.LoadAssetAtPath<EnemyTypeScriptableObject>(assetPath);
            
            Assert.AreEqual(enemyType, enemyTypeSelector.GetEnemyByTypeName(fizzBuzzLogicName));
        }

    }
}