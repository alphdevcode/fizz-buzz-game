using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using NUnit.Framework;
using UnityEditor;

namespace Tests
{
    public class WeaponSelectorTests
    {
        private const string WeaponDataPath = "Assets/_Project/Scripts/Weapons/Data";

        private readonly WeaponSelectorScriptableObject _weaponSelector =
            AssetDatabase.LoadAssetAtPath<WeaponSelectorScriptableObject>($"{WeaponDataPath}/WeaponSelector.asset");


        [Test]
        [TestCase(FizzBuzzLogicType.Dumb, "DumbWeapon")]
        [TestCase(FizzBuzzLogicType.Fizz, "FizzWeapon")]
        [TestCase(FizzBuzzLogicType.Buzz, "BuzzWeapon")]
        [TestCase(FizzBuzzLogicType.FizzBuzz, "FizzBuzzWeapon")]
        public void Given_EnemyType_Then_Weapon(FizzBuzzLogicType fizzBuzzLogicType, string expectedWeaponName)
        {
            var weapon =
                AssetDatabase.LoadAssetAtPath<WeaponScriptableObject>($"{WeaponDataPath}/{expectedWeaponName}.asset");

            Assert.AreEqual(weapon, _weaponSelector.GetWeaponData(fizzBuzzLogicType));
        }
    }
}