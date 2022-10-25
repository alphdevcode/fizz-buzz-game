using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using NUnit.Framework;
using UnityEditor;

namespace Tests
{
    public class WeaponSelectorTests
    {
        private WeaponSelectorScriptableObject _weaponSelector;

        [OneTimeSetUp]
        public void InitializeWeaponTypeSelector()
        {
            var assetNames = AssetDatabase.FindAssets("WeaponSelector",
                new[] { "Assets/_Project/Scripts/Weapons/Data" });
            var assetPath = AssetDatabase.GUIDToAssetPath(assetNames[0]);
            _weaponSelector = AssetDatabase.LoadAssetAtPath<WeaponSelectorScriptableObject>(assetPath);
        }

        [Test]
        [TestCase(FizzBuzzLogicType.DUMB, "DumbWeapon")]
        [TestCase(FizzBuzzLogicType.FIZZ, "FizzWeapon")]
        [TestCase(FizzBuzzLogicType.BUZZ, "BuzzWeapon")]
        [TestCase(FizzBuzzLogicType.FIZZBUZZ, "FizzBuzzWeapon")]
        public void Given_EnemyType_Then_Weapon(FizzBuzzLogicType fizzBuzzLogicType, string expectedWeaponName)
        {
            var assetNames = AssetDatabase.FindAssets($"{expectedWeaponName}",
                new[] { "Assets/_Project/Scripts/Weapons/Data" });
            var assetPath = AssetDatabase.GUIDToAssetPath(assetNames[0]);
            var weapon = AssetDatabase.LoadAssetAtPath<WeaponScriptableObject>(assetPath);

            Assert.AreEqual(weapon, _weaponSelector.GetWeaponData(fizzBuzzLogicType));
        }
    }
}