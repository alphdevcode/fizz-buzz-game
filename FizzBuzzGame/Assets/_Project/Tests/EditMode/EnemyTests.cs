using AlphDevCode.Enemies;
using NUnit.Framework;
using UnityEngine;

namespace AlphDevCode.Test.EditMode
{
    public class EnemyTests
    {
        [Test]
        public void Given_TakeDamage_Then_Die()
        {
            var gameObject = new GameObject
            {
                transform = { position = Vector3.zero }
            };
            var enemy = gameObject.AddComponent<EnemyHealth>();

            enemy.TakeDamage();

            Assert.IsFalse(enemy.GetComponent<BoxCollider>().enabled);
        }
    }
}